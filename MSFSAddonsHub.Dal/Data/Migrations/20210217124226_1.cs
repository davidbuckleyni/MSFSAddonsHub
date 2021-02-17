using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSFSAddonsHub.Dal.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongX = table.Column<decimal>(type: "decimal(18,9)", nullable: true),
                    LatY = table.Column<decimal>(type: "decimal(18,9)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                });

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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GamerTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isOnline = table.Column<bool>(type: "bit", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    AvatarImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TennantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "NEWID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubLikes = table.Column<int>(type: "int", nullable: true),
                    ClubDislikes = table.Column<int>(type: "int", nullable: true),
                    MembersCount = table.Column<int>(type: "int", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpdrRemoveRequestDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    isGpdrRemoveRequest = table.Column<bool>(type: "bit", nullable: true),
                    BannedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    BanPeriod = table.Column<TimeSpan>(type: "time", nullable: true),
                    isBanned = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teir = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConflictId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isDisplayHomePage = table.Column<bool>(type: "bit", nullable: true),
                    isFeatured = table.Column<bool>(type: "bit", nullable: true),
                    ThumbNailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IPAddressBytes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyDashBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserScreenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadCount = table.Column<int>(type: "int", nullable: true),
                    FollowingClubsCount = table.Column<int>(type: "int", nullable: true),
                    LikedFilesCount = table.Column<int>(type: "int", nullable: true),
                    GpdrRemoveRequestDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    isGpdrRemoveRequest = table.Column<bool>(type: "bit", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyDashBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPDRReqestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GpdrRemoval = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Langague = table.Column<int>(type: "int", nullable: false),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    ChatOnOff = table.Column<bool>(type: "bit", nullable: true),
                    EmailNotificaitons = table.Column<bool>(type: "bit", nullable: true),
                    ColorTheme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BadgeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BadgePoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubInvites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserFromId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserToId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    To = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiresHours = table.Column<int>(type: "int", nullable: true),
                    ReferLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUserAccepted = table.Column<bool>(type: "bit", nullable: true),
                    hasUserAccepted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubInvites_AspNetUsers_UserFromId",
                        column: x => x.UserFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubInvites_AspNetUsers_UserToId",
                        column: x => x.UserToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FriendIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    hasExcepted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    RequestedIp = table.Column<int>(type: "int", nullable: true),
                    isBlocked = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_FriendIdId",
                        column: x => x.FriendIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendsRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreindRequestedIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FriendIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequestedIp = table.Column<int>(type: "int", nullable: true),
                    hasAccepted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    isBlocked = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendsRequest_AspNetUsers_FreindRequestedIdId",
                        column: x => x.FreindRequestedIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendsRequest_AspNetUsers_FriendIdId",
                        column: x => x.FriendIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    isRead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    MemeberOfClub = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BannedStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BannedEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isBanned = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubMembers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubMembers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestAirportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeinMins = table.Column<int>(type: "int", nullable: true),
                    TimeInFluent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    FlightDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightPlanXML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightPlanUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HttpDownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadServiceType = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoldersId = table.Column<int>(type: "int", nullable: true),
                    ConflictId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrignalFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDownloads = table.Column<int>(type: "int", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    canBeDownloadedByOtherUsers = table.Column<bool>(type: "bit", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtensionIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isZipFile = table.Column<bool>(type: "bit", nullable: true),
                    isJsonFile = table.Column<bool>(type: "bit", nullable: true),
                    DownloadJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isDisplayHomePage = table.Column<bool>(type: "bit", nullable: true),
                    isFeatured = table.Column<bool>(type: "bit", nullable: true),
                    ThumbNailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IPAddressBytes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileManager_FileFolders_FoldersId",
                        column: x => x.FoldersId,
                        principalTable: "FileFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightsRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICAOCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightsRoutes_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAddons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddonType = table.Column<int>(type: "int", nullable: true),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddonCategoryId = table.Column<int>(type: "int", nullable: true),
                    ConflictId = table.Column<int>(type: "int", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDownloads = table.Column<int>(type: "int", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isZipFile = table.Column<bool>(type: "bit", nullable: true),
                    isJsonFile = table.Column<bool>(type: "bit", nullable: true),
                    DownloadJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    isDisplayHomePage = table.Column<bool>(type: "bit", nullable: true),
                    isFeatured = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddons_Category_AddonCategoryId",
                        column: x => x.AddonCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAddons_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubsDownloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeannatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsDownloads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubsDownloads_FileManager_FileId",
                        column: x => x.FileId,
                        principalTable: "FileManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f35f00c-e4c2-47a6-b87c-5da3f232c3fb", "7ac6f95e-0854-44c8-9a1e-2a2a694efb0c", "Admin", "ADMIN" },
                    { "f2f2b605-6f0b-4e83-87c1-a28c25e768a1", "c804e673-a0e0-43b3-ba8d-d5ac24f4c220", "ClubSuperAdmin", "SUPERADMIN" },
                    { "01c16e64-75a3-4019-b723-5c117a195f08", "6969665b-c27a-4934-8b8e-6f798ca24097", "ClubMod", "CLUBMOD" },
                    { "f1434258-391d-4d89-a898-df216f7b75e6", "2ac4900f-f296-4e97-94d6-fee94132bf9f", "ClubUser", "CLUBUSER" }
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
                name: "IX_Badges_ApplicationUserId",
                table: "Badges",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubInvites_UserFromId",
                table: "ClubInvites",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubInvites_UserToId",
                table: "ClubInvites",
                column: "UserToId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_ClubId",
                table: "ClubMembers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_RoleId",
                table: "ClubMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_UserId",
                table: "ClubMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsDownloads_FileId",
                table: "ClubsDownloads",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileManager_FoldersId",
                table: "FileManager",
                column: "FoldersId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ClubId",
                table: "Flights",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsRoutes_FlightId",
                table: "FlightsRoutes",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendIdId",
                table: "Friends",
                column: "FriendIdId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsRequest_FreindRequestedIdId",
                table: "FriendsRequest",
                column: "FreindRequestedIdId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsRequest_FriendIdId",
                table: "FriendsRequest",
                column: "FriendIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ApplicationUserId",
                table: "Notifications",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddons_AddonCategoryId",
                table: "UserAddons",
                column: "AddonCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddons_FlightId",
                table: "UserAddons",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airport");

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
                name: "Badges");

            migrationBuilder.DropTable(
                name: "ClubInvites");

            migrationBuilder.DropTable(
                name: "ClubMembers");

            migrationBuilder.DropTable(
                name: "ClubsDownloads");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "FlightsRoutes");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "FriendsRequest");

            migrationBuilder.DropTable(
                name: "MyDashBoard");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "UserAddons");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FileManager");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "FileFolders");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
