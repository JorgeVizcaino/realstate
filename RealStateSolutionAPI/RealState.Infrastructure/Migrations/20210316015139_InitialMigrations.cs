using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealState.Infrastructure.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DBO");

            migrationBuilder.CreateTable(
                name: "ApplianceOwnership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    refrigerator = table.Column<string>(nullable: true),
                    dishwasher = table.Column<string>(nullable: true),
                    washer = table.Column<string>(nullable: true),
                    dryer = table.Column<string>(nullable: true),
                    microwave = table.Column<string>(nullable: true),
                    stove = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceOwnership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Financial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    capRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    occupancy = table.Column<string>(nullable: true),
                    isSection8 = table.Column<bool>(nullable: false),
                    leaseStartDate = table.Column<DateTime>(nullable: false),
                    leaseEndDate = table.Column<DateTime>(nullable: false),
                    listPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    salePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    marketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    monthlyHoa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    monthlyManagementFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    monthlyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    netYield = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    turnOverFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    rehabCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    rehabDate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    yearlyInsuranceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    yearlyPropertyTaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isCashOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoogleMapOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    hasStreetView = table.Column<bool>(nullable: false),
                    povHeading = table.Column<int>(nullable: false),
                    povPitch = table.Column<int>(nullable: false),
                    povLatitude = table.Column<double>(nullable: false),
                    povLongitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleMapOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaseSummary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    occupancy = table.Column<string>(nullable: true),
                    leasingStatus = table.Column<string>(nullable: true),
                    marketedRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    paymentStatus = table.Column<string>(nullable: true),
                    leaseStartDate = table.Column<DateTime>(nullable: false),
                    leaseEndDate = table.Column<DateTime>(nullable: false),
                    monthlyRent = table.Column<double>(nullable: false),
                    securityDepositAmount = table.Column<double>(nullable: true),
                    hasPet = table.Column<bool>(nullable: true),
                    petFeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isPetsDeposit = table.Column<bool>(nullable: false),
                    petsDepositAmount = table.Column<double>(nullable: true),
                    isLeaseConcessions = table.Column<bool>(nullable: true),
                    isRentersInsuranceRequired = table.Column<bool>(nullable: false),
                    isSection8 = table.Column<bool>(nullable: false),
                    isTenantBackgroundChecked = table.Column<bool>(nullable: false),
                    isTenantIncomeAbove3x = table.Column<bool>(nullable: false),
                    isTenantMayTerminateEarly = table.Column<bool>(nullable: true),
                    isTenantPurchaseOption = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseSummary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Physical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    bathRooms = table.Column<double>(nullable: false),
                    bedRooms = table.Column<double>(nullable: false),
                    parcelNumber = table.Column<string>(nullable: true),
                    isPool = table.Column<bool>(nullable: false),
                    lotSize = table.Column<int>(nullable: true),
                    squareFeet = table.Column<int>(nullable: false),
                    stories = table.Column<string>(nullable: true),
                    units = table.Column<string>(nullable: true),
                    yearBuilt = table.Column<int>(nullable: false),
                    zipYearBuilt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    conditionScore = table.Column<int>(nullable: true),
                    crimeScore = table.Column<string>(nullable: true),
                    neighborhoodScore = table.Column<int>(nullable: false),
                    overallScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    qualityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    schoolScore = table.Column<string>(nullable: true),
                    charterSchoolScore = table.Column<string>(nullable: true),
                    floodRiskScore = table.Column<string>(nullable: true),
                    walkabilityScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesOwnership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    electric = table.Column<string>(nullable: true),
                    gas = table.Column<string>(nullable: true),
                    water = table.Column<string>(nullable: true),
                    garbage = table.Column<string>(nullable: true),
                    pool = table.Column<string>(nullable: true),
                    landscaping = table.Column<string>(nullable: true),
                    pestControl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesOwnership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valuation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    avmBpoValue = table.Column<string>(nullable: true),
                    avmBpoAdjValue = table.Column<string>(nullable: true),
                    avmBpoDate = table.Column<DateTime>(nullable: true),
                    rsAvmValue = table.Column<string>(nullable: true),
                    rsAvmDate = table.Column<DateTime>(nullable: true),
                    rsBpoMergeValue = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "DBO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    address1 = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    county = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true),
                    zipPlus4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Audios",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ResourcesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audios_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FloorPlan",
                columns: table => new
                {
                    IdFloorPlan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    guid = table.Column<string>(nullable: true),
                    resourceType = table.Column<string>(nullable: true),
                    isPublic = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    filename = table.Column<string>(nullable: true),
                    sizeInByte = table.Column<string>(nullable: true),
                    contentType = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    urlMedium = table.Column<string>(nullable: true),
                    urlSmall = table.Column<string>(nullable: true),
                    textContent = table.Column<string>(nullable: true),
                    ResourcesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorPlan", x => x.IdFloorPlan);
                    table.ForeignKey(
                        name: "FK_FloorPlan_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    guid = table.Column<string>(nullable: true),
                    resourceType = table.Column<string>(nullable: true),
                    isPublic = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    filename = table.Column<string>(nullable: true),
                    sizeInByte = table.Column<int>(nullable: true),
                    contentType = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    urlMedium = table.Column<string>(nullable: true),
                    urlSmall = table.Column<string>(nullable: true),
                    textContent = table.Column<string>(nullable: true),
                    ResourcesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photo_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThreeDRendering",
                columns: table => new
                {
                    ThreeDRenderingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    guid = table.Column<string>(nullable: true),
                    resourceType = table.Column<string>(nullable: true),
                    isPublic = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    filename = table.Column<string>(nullable: true),
                    sizeInByte = table.Column<string>(nullable: true),
                    contentType = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    urlMedium = table.Column<string>(nullable: true),
                    urlSmall = table.Column<string>(nullable: true),
                    textContent = table.Column<string>(nullable: true),
                    ResourcesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreeDRendering", x => x.ThreeDRenderingId);
                    table.ForeignKey(
                        name: "FK_ThreeDRendering_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lease",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    leaseSummaryId = table.Column<int>(nullable: true),
                    utilitiesOwnershipId = table.Column<int>(nullable: true),
                    applianceOwnershipId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lease_ApplianceOwnership_applianceOwnershipId",
                        column: x => x.applianceOwnershipId,
                        principalTable: "ApplianceOwnership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lease_LeaseSummary_leaseSummaryId",
                        column: x => x.leaseSummaryId,
                        principalTable: "LeaseSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lease_UtilitiesOwnership_utilitiesOwnershipId",
                        column: x => x.utilitiesOwnershipId,
                        principalTable: "UtilitiesOwnership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                schema: "DBO",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    accountId = table.Column<int>(nullable: false),
                    buyerAccountId = table.Column<int>(nullable: true),
                    buyerUserId = table.Column<int>(nullable: true),
                    externalId = table.Column<int>(nullable: true),
                    programId = table.Column<int>(nullable: true),
                    isDwellCertified = table.Column<bool>(nullable: false),
                    isAllowOffer = table.Column<bool>(nullable: false),
                    isAllowPreview = table.Column<bool>(nullable: false),
                    isFeatured = table.Column<bool>(nullable: false),
                    isRentGuaranteed = table.Column<bool>(nullable: false),
                    allowRentGuaranteedOptout = table.Column<bool>(nullable: false),
                    isSecuritized = table.Column<bool>(nullable: false),
                    isHot = table.Column<bool>(nullable: false),
                    isNew = table.Column<bool>(nullable: false),
                    isBargain = table.Column<bool>(nullable: true),
                    isDiligenceVaultUnlocked = table.Column<bool>(nullable: false),
                    isPropertyManagerOfferRetain = table.Column<bool>(nullable: true),
                    isHoa = table.Column<bool>(nullable: true),
                    hasAudio = table.Column<bool>(nullable: false),
                    hasDiligenceVaultDocuments = table.Column<bool>(nullable: false),
                    market = table.Column<int>(nullable: false),
                    daysOnMarket = table.Column<int>(nullable: true),
                    latitude = table.Column<double>(nullable: true),
                    longitude = table.Column<double>(nullable: true),
                    propertyName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    highlights = table.Column<string>(nullable: true),
                    mainImageUrl = table.Column<string>(nullable: true),
                    personalProperties = table.Column<string>(nullable: true),
                    diligenceVaultSummary = table.Column<string>(nullable: true),
                    featuredReason = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    allowedFundingTypes = table.Column<string>(nullable: true),
                    allowableSaleTypes = table.Column<string>(nullable: true),
                    visibility = table.Column<string>(nullable: true),
                    priceVisibility = table.Column<string>(nullable: true),
                    propertyType = table.Column<string>(nullable: true),
                    certificationLevel = table.Column<string>(nullable: true),
                    escrowClosingDate = table.Column<DateTime>(nullable: true),
                    addressId = table.Column<int>(nullable: true),
                    financialId = table.Column<int>(nullable: true),
                    physicalId = table.Column<int>(nullable: true),
                    scoreId = table.Column<int>(nullable: true),
                    valuationid = table.Column<int>(nullable: true),
                    resourcesId = table.Column<int>(nullable: true),
                    manager = table.Column<string>(nullable: true),
                    seller = table.Column<string>(nullable: true),
                    sellerBroker = table.Column<string>(nullable: true),
                    hoa = table.Column<string>(nullable: true),
                    leaseId = table.Column<int>(nullable: true),
                    googleMapOptionId = table.Column<int>(nullable: true),
                    inspectionType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Address_addressId",
                        column: x => x.addressId,
                        principalSchema: "DBO",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Financial_financialId",
                        column: x => x.financialId,
                        principalTable: "Financial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_GoogleMapOption_googleMapOptionId",
                        column: x => x.googleMapOptionId,
                        principalTable: "GoogleMapOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Lease_leaseId",
                        column: x => x.leaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Physical_physicalId",
                        column: x => x.physicalId,
                        principalTable: "Physical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Resources_resourcesId",
                        column: x => x.resourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Score_scoreId",
                        column: x => x.scoreId,
                        principalTable: "Score",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Valuation_valuationid",
                        column: x => x.valuationid,
                        principalTable: "Valuation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diligences",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diligences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diligences_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "DBO",
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Audios_ResourcesId",
                table: "Audios",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Diligences_PropertyId",
                table: "Diligences",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorPlan_ResourcesId",
                table: "FloorPlan",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Lease_applianceOwnershipId",
                table: "Lease",
                column: "applianceOwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Lease_leaseSummaryId",
                table: "Lease",
                column: "leaseSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lease_utilitiesOwnershipId",
                table: "Lease",
                column: "utilitiesOwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ResourcesId",
                table: "Photo",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreeDRendering_ResourcesId",
                table: "ThreeDRendering",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_addressId",
                schema: "DBO",
                table: "Property",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_financialId",
                schema: "DBO",
                table: "Property",
                column: "financialId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_googleMapOptionId",
                schema: "DBO",
                table: "Property",
                column: "googleMapOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_leaseId",
                schema: "DBO",
                table: "Property",
                column: "leaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_physicalId",
                schema: "DBO",
                table: "Property",
                column: "physicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_resourcesId",
                schema: "DBO",
                table: "Property",
                column: "resourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_scoreId",
                schema: "DBO",
                table: "Property",
                column: "scoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_valuationid",
                schema: "DBO",
                table: "Property",
                column: "valuationid");
        }

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
                name: "Audios");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Diligences");

            migrationBuilder.DropTable(
                name: "FloorPlan");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "ThreeDRendering");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Property",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Financial");

            migrationBuilder.DropTable(
                name: "GoogleMapOption");

            migrationBuilder.DropTable(
                name: "Lease");

            migrationBuilder.DropTable(
                name: "Physical");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Valuation");

            migrationBuilder.DropTable(
                name: "ApplianceOwnership");

            migrationBuilder.DropTable(
                name: "LeaseSummary");

            migrationBuilder.DropTable(
                name: "UtilitiesOwnership");
        }
    }
}
