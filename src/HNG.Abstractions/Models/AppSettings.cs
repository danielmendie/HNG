namespace HNG.Abstractions.Models
{
    public class AppSettings
    {
        public int AppId { get; set; }
        public string AppName { get; set; } = null!;
        public SettingsObject Settings { get; set; } = new SettingsObject();
        public ConnectionStringsObject ConnectionStrings { get; set; } = new ConnectionStringsObject();
        public OpenIdSettings OpenId { get; set; } = new OpenIdSettings();
        public IdentityServerSettings IdentityServer { get; set; } = new IdentityServerSettings();
        public SwaggerSettings Swagger { get; set; } = new SwaggerSettings();
        public CorsPolicy CorsPolicies { get; set; } = new CorsPolicy();
        public SerilogSettings Serilog { get; set; } = new SerilogSettings();


        public class OpenIdSettings
        {
            public string Authority { get; set; } = null!;
            public string Audience { get; set; } = null!;
            public List<string> TokenValidationParametersValidTypes { get; set; } = new List<string>();
        }

        public class CorsPolicy
        {
            public List<string> AllowedUris { get; set; } = new List<string>();
        }

        public class SwaggerSettings
        {
            public bool Enabled { get; set; }
            public string EndpointUrl { get; set; } = null!;
            public string EndpointName { get; set; } = null!;
            public SwaggerOAuthSettings OAuth { get; set; } = new SwaggerOAuthSettings();
            public List<SwaggerDocumentSettings> Documents { get; set; } = new List<SwaggerDocumentSettings>();
            public List<SwaggerSecurityDefinition> SecurityDefinitions { get; set; } = new List<SwaggerSecurityDefinition>();
        }

        public class ConnectionStringsObject
        {
            public string ConnectionString { get; set; } = null!;
        }

        public class SettingsObject
        {
            public bool UseMockForDatabase { get; set; }
            public bool RequireSSL { get; set; }
            public bool UseMockForIntegrations { get; set; }
            public bool UseMockForAuthentication { get; set; }
            public bool UseMockForAuthenticationOverride { get; set; }
            public bool InTestMode { get; set; }
            public int TokenLifetimeMinutes { get; set; }
            public int GeneratedCodeLifetimeMinutes { get; set; }
            public string AdminMailboxEmail { get; set; } = null!;
            public string AdminMailboxName { get; set; } = null!;
            public bool DisableDeviceRegistration { get; set; }
            public bool EnableDetailedErrorMessages { get; set; }

            public string? ApplicationLink { get; set; }
            public string? DefaultRedirectLink { get; set; }
            public string? MockProfileId { get; set; }
            public string? MockUserId { get; set; }
            public string? MockUserName { get; set; }
            public string? MockCompanyId { get; set; }

            public string? EnquiriesBaseUrl { get; set; }
            public string? InvesmentsBaseUrl { get; set; }
            public string? ReportSetUpBaseUrl { get; set; }
            public string? TransactionsBaseUrl { get; set; }
            public string? NibssPayBaseUrl { get; set; }
            public string? NotificationsBaseUrl { get; set; }
            public string? NipBaseUrl { get; set; }
            public string? NapsBaseUrl { get; set; }
            public string? ApiConnectNapsBaseUrl { get; set; }
            public string? AdminTokenBaseUrl { get; set; }
            public string? CustomerTokenBaseUrl { get; set; }
            public string? MFAFeeAccountNumber { get; set; }
            public string? MFAFeeAccountName { get; set; }
            public string? TermDepositAccountNumber { get; set; }
            public string? TermDepositAccountName { get; set; }
        }

        public class IdentityServerSettings

        {
            public bool IncludeTestClient { get; set; }

            public string TestClientSecret { get; set; } = null!;
            public string WebClientSecret { get; set; } = null!;
            public string IntegrationClientSecret { get; set; } = null!;
            public string ApiResourceSecret { get; set; } = null!;
            public List<string> RedirectUris { get; set; } = new List<string>();
            public List<string> AppRedirectUris { get; set; } = new List<string>();
            public string FrontChannelLogoutUri { get; set; } = null!;
            public List<string> PostLogoutRedirectUris { get; set; } = new List<string>();
            public int MaxFailedAccessAttempts { get; set; } = 5;
            public int DefaultLockoutMinutes { get; set; } = 30;
        }

        public class SwaggerOAuthSettings
        {
            public string AppName { get; set; } = null!;
            public string? DefaultClientId { get; set; }
            public string? DefaultClientSecret { get; set; }
            public bool UsePkce { get; set; }
        }

        public class SwaggerDocumentSettings
        {
            public string Version { get; set; } = null!;
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
        }

        public class SwaggerSecurityDefinition
        {
            public string Id { get; set; } = null!;
            public string Name { get; set; } = null!;
            public string SchemeType { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string AuthorizationUrl { get; set; } = null!;
            public string TokenUrl { get; set; } = null!;
            public SwaggerOAuthFlows Flows { get; set; } = new SwaggerOAuthFlows();
        }

        public class SwaggerOAuthFlows
        {
            public SwaggerOAuthAuthCodeFlow AuthorizationCode { get; set; } = new SwaggerOAuthAuthCodeFlow();
            public SwaggerOAuthClientCredentialsFlow ClientCredentials { get; set; } = new SwaggerOAuthClientCredentialsFlow();
        }

        public class SwaggerOAuthAuthCodeFlow
        {
            public List<Scope> Scopes { get; set; } = new List<Scope>();
        }

        public class SwaggerOAuthClientCredentialsFlow
        {
            public List<Scope> Scopes { get; set; } = new List<Scope>();
        }

        public class Scope
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
        }

        public class SerilogSinkArgs
        {
            public string? outputTemplate { get; set; }
            public string? path { get; set; }
            public string? rollingInterval { get; set; }
            public string? formatter { get; set; }
        }

        public class SerilogMinimumLevel
        {
            public string Default { get; set; } = null!;
            public SerilogOverride Override { get; set; } = new SerilogOverride();
        }

        public class SerilogOverride
        {
            public string Microsoft { get; set; } = null!;
            public string System { get; set; } = null!;
        }

        public class SerilogSettings
        {
            public List<string> Using { get; set; } = new List<string>();
            public SerilogMinimumLevel MinimumLevel { get; set; } = new SerilogMinimumLevel();
            public List<string> Enrich { get; set; } = new List<string>();
            public List<SerilogWriteTo> WriteTo { get; set; } = new List<SerilogWriteTo>();
        }

        public class SerilogWriteTo
        {
            public string Name { get; set; } = null!;
            public SerilogSinkArgs Args { get; set; } = new SerilogSinkArgs();
        }
    }
}
