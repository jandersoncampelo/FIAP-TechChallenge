using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.API.Application.Interfaces;
using InvestmentPortal.API.Application.Services;
using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;
using Moq;

namespace InvestmentPortal.Tests.Application
{
    public class AssetAppServiceTests
    {
        private readonly Mock<IAssetRepository> _repositoryMock;
        private readonly IAssetAppService _assetAppService;

        public AssetAppServiceTests()
        {
            _repositoryMock = new Mock<IAssetRepository>();
            _assetAppService = new AssetAppService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_WithValidData_ReturnsAssetDto()
        {
            // Arrange
            var createDTO = new AssetCreateDto
            (
                "AAPL",
                AssetType.Stock,
                "Apple Inc.",
                "Technology company"
            );

            var asset = new Asset(createDTO.Symbol, createDTO.Type, createDTO.Name, createDTO.Description);
            var assetDto = AssetDto.FromAsset(asset);

            _repositoryMock.Setup(r => r.GetBySymbolAsync(createDTO.Symbol)).ReturnsAsync((Asset)null);
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Asset>())).ReturnsAsync(asset);

            // Act
            var result = await _assetAppService.CreateAsync(createDTO);

            // Assert
            Assert.Equal(assetDto, result);
            _repositoryMock.Verify(r => r.GetBySymbolAsync(createDTO.Symbol), Times.Once);
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Asset>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_WithNullCreateDTO_ThrowsArgumentNullException()
        {
            // Arrange
            AssetCreateDto createDTO = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _assetAppService.CreateAsync(createDTO));
        }

        [Fact]
        public async Task CreateAsync_WithEmptySymbol_ThrowsArgumentNullException()
        {
            // Arrange
            var createDTO = new AssetCreateDto
            (
                null,
                AssetType.Stock,
                "Apple Inc.",
                "Technology company"
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _assetAppService.CreateAsync(createDTO));
        }

        [Fact]
        public async Task CreateAsync_WithExistingSymbol_ThrowsException()
        {
            // Arrange
            var createDTO = new AssetCreateDto
            (
                "AAPL",
                AssetType.Stock,
                "Apple Inc.",
                "Technology company"
            );

            _repositoryMock.Setup(r => r.GetBySymbolAsync(createDTO.Symbol)).ReturnsAsync(new Asset());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _assetAppService.CreateAsync(createDTO));
        }
    }
}
