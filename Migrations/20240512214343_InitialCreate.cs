using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranaWarePc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUCoolers",
                columns: table => new
                {
                    CPUCoolerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    CPUCoolerSocket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerCoolingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerBearing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerNrVents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerPWMVent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerRotationSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerPumpSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerAirflux = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerNoise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerPumpNoise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerAirPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerConnector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerPumpConnector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerDimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerLED = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolerLCD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolers", x => x.CPUCoolerID);
                    table.ForeignKey(
                        name: "FK_CPUCoolers_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    CPUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    CPUPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUSocket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoreNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUThreadNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUBaseClock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUMaxBoostClock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUL3Cache = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUL2Cache = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUMaxTemp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUTDP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPULaunchDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.CPUID);
                    table.ForeignKey(
                        name: "FK_CPUs_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    GPUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    GPUInterface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUMaxResolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUCooling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUTechnology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUGraphicProcessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUBostClock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUShaderModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUTextureUnits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPURasterOperators = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUCudaCores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUMemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUMemorySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUMemoryBus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUMemoryFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUHDMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUDisplayPort = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.GPUID);
                    table.ForeignKey(
                        name: "FK_GPUs_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HDDs",
                columns: table => new
                {
                    HDDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    HDDSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDDInterface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDDCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDDBuffer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDDSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDDFormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDDNASRecommend = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDs", x => x.HDDID);
                    table.ForeignKey(
                        name: "FK_HDDs_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    MotherboardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    MotherboardFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardSocket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardChipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardChipsetProducer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardChipsetModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardSupportedCPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardGraphicInterface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardRAID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardIntegratedGraphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardIntegratedAudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardAudioChipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardIntegratedNetwork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardNetworkChipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardDiskSlots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardMemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardMaxMemory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardMemorySlots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardMemTechnology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardSupportedFreq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardPCISlots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherboardBackPorts = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.MotherboardID);
                    table.ForeignKey(
                        name: "FK_Motherboards_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCCases",
                columns: table => new
                {
                    PCCaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    PCCaseCompatibleMB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCasePSUPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCasePSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseBays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseDimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseMesh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseSidePanel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseExpSlots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseRadiatorSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseOther = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseCPUCoolerHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseGPUCoolerHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCasePorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCCaseCoolers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCCases", x => x.PCCaseID);
                    table.ForeignKey(
                        name: "FK_PCCases_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSUs",
                columns: table => new
                {
                    PSUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    PSUType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUVents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUNoise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUPFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUEfficiency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUCertification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUDimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUModular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUPorts = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSUs", x => x.PSUID);
                    table.ForeignKey(
                        name: "FK_PSUs_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAMs",
                columns: table => new
                {
                    RAMID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    RAMSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMDualChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMLatency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMRadiator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemStandard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemTension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemTiming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMMemLED = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMs", x => x.RAMID);
                    table.ForeignKey(
                        name: "FK_RAMs_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    SSDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcComponentId = table.Column<int>(type: "int", nullable: false),
                    SSDSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDFormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDInterface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDNVMeSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDMaxRead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDMaxWrite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDRandom4KBRead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSDRandom4KBWrite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.SSDID);
                    table.ForeignKey(
                        name: "FK_SSDs_PCComponents_PcComponentId",
                        column: x => x.PcComponentId,
                        principalTable: "PCComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCoolers_PcComponentId",
                table: "CPUCoolers",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_PcComponentId",
                table: "CPUs",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_PcComponentId",
                table: "GPUs",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_PcComponentId",
                table: "HDDs",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_PcComponentId",
                table: "Motherboards",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PCCases_PcComponentId",
                table: "PCCases",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_PcComponentId",
                table: "PSUs",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_PcComponentId",
                table: "RAMs",
                column: "PcComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_PcComponentId",
                table: "SSDs",
                column: "PcComponentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CPUCoolers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "HDDs");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "PCCases");

            migrationBuilder.DropTable(
                name: "PSUs");

            migrationBuilder.DropTable(
                name: "RAMs");

            migrationBuilder.DropTable(
                name: "SSDs");

            migrationBuilder.DropTable(
                name: "Upgrades");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PCComponents");
        }
    }
}
