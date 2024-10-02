using Blazored.LocalStorage;
using Blazored.Toast;
using MASCIS.WEB;
using MASCIS.WEB.AuthProviders;
using MASCIS.WEB.Interface;
using MASCIS.WEB.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Syncfusion.Blazor;
using static MASCIS.WEB.Pages.Account.ChangeUserPasswordPage;
using static MASCIS.WEB.Pages.Account.ContactsPage;
using static MASCIS.WEB.Pages.Account.UserManagementPage;
using static MASCIS.WEB.Pages.ComplaintHandling.SubmittedComplaintsPage;
using static MASCIS.WEB.Pages.OrderForm.ApprovedForExportPage;
using static MASCIS.WEB.Pages.OrderForm.OrderFormPage;
using static MASCIS.WEB.Pages.OrderForm.OrderLMISCordinatorPage;
using static MASCIS.WEB.Pages.Pharmacovigilance.AEFIReportingFormPage;
using static MASCIS.WEB.Pages.Pharmacovigilance.SADRRReportingPage;
using static MASCIS.WEB.Pages.PhysicalCount.PhysicalCountPage;
using static MASCIS.WEB.Pages.QualityAudit.QualityAuditPage;
using static MASCIS.WEB.Pages.Regulatory.CgmpInspectionStatusPage;
using static MASCIS.WEB.Pages.Regulatory.MarketAuthorizationStatusPage;
using static MASCIS.WEB.Pages.Regulatory.VariationStatusPage;
using static MASCIS.WEB.Pages.Regulatory.DrugRegistrationStatusPage;
using MASCIS.WEB.Features;
using static MASCIS.WEB.Pages.utilities.A.AART_Product_ClassificationPage;
using static MASCIS.WEB.Pages.utilities.A.AAdverseEventPage;
using static MASCIS.WEB.Pages.utilities.A.A_AgeGroupsPage;
using static MASCIS.WEB.Pages.utilities.A.AAuditSectionPage;
using static MASCIS.WEB.Pages.utilities.A.AAuthorizedRepresentativePage;
using static MASCIS.WEB.Pages.utilities.C.ACapaCompletionStatusPage;
using static MASCIS.WEB.Pages.utilities.C.ACapaRegisterStatusPage;
using static MASCIS.WEB.Pages.utilities.C.ACDCRegionPage;
using static MASCIS.WEB.Pages.utilities.Y.AYesNoPage;
using static MASCIS.WEB.Pages.utilities.V.AVillagePage;
using static MASCIS.WEB.Pages.utilities.V.AVerificationMethodPage;
using static MASCIS.WEB.Pages.utilities.V.AVariationStatusPage;
using static MASCIS.WEB.Pages.utilities.T.ATrimesterPage;
using static MASCIS.WEB.Pages.utilities.T.ATreatmentCategoryPage;
using static MASCIS.WEB.Pages.utilities.T.ATreatmentPage;
using static MASCIS.WEB.Pages.utilities.S.ASupplierPage;
using static MASCIS.WEB.Pages.utilities.C.ACountyPage;
using static MASCIS.WEB.Pages.utilities.S.ASubcountyPage;
using static MASCIS.WEB.Pages.utilities.S.ASectorChangePage;
using static MASCIS.WEB.Pages.utilities.S.A_SAP_Batch_InformationPage;
using static MASCIS.WEB.Pages.utilities.R.AReleaseInstructionPage;
using static MASCIS.WEB.Pages.utilities.R.ARegistrationStatusPage;
using static MASCIS.WEB.Pages.utilities.R.ARegionPage;
using static MASCIS.WEB.Pages.utilities.P.APVSatusPage;
using static MASCIS.WEB.Pages.utilities.P.APVReportingTypePage;
using static MASCIS.WEB.Pages.utilities.C.AClientTypePage;
using static MASCIS.WEB.Pages.utilities.C.ACommunicationModePage;
using static MASCIS.WEB.Pages.utilities.C.AComplaintActionTakenPage;
using static MASCIS.WEB.Pages.utilities.C.AComplaintCategoryPage;
using static MASCIS.WEB.Pages.utilities.C.AComplaintClassificationPage;
using static MASCIS.WEB.Pages.utilities.C.AComplaintConfirmationStatusPage;
using static MASCIS.WEB.Pages.utilities.C.AComplaintReportingGroupPage;
using static MASCIS.WEB.Pages.utilities.C.AComplaintStatusPage;
using static MASCIS.WEB.Pages.utilities.C.ACompletionTimeScalePage;
using static MASCIS.WEB.Pages.utilities.C.AContactTitlePage;
using static MASCIS.WEB.Pages.utilities.C.AContactCategoryPage;
using static MASCIS.WEB.Pages.utilities.C.ACountryPage;
using static MASCIS.WEB.Pages.utilities.D.ADeliveryZonePage;
using static MASCIS.WEB.Pages.utilities.D.ADistrictPage;
using static MASCIS.WEB.Pages.utilities.D.ADosePage;
using static MASCIS.WEB.Pages.utilities.D.ADrugRegimenPage;
using static MASCIS.WEB.Pages.utilities.D.ADrugRegimenCategoryPage;
using static MASCIS.WEB.Pages.utilities.D.ADrugRegimenClassificationPage;
using static MASCIS.WEB.Pages.utilities.D.ADrugBasicUnitPage;
using static MASCIS.WEB.Pages.utilities.G.AGenderPage;
using static MASCIS.WEB.Pages.utilities.I.AImplimentingPartnersPage;
using static MASCIS.WEB.Pages.utilities.I.AInspectionStatusPage;

using static MASCIS.WEB.Pages.utilities.L.ALabCategory1Page;
using static MASCIS.WEB.Pages.utilities.L.ALabCategory2Page;
using static MASCIS.WEB.Pages.utilities.L.ALabCategory3Page;
using static MASCIS.WEB.Pages.utilities.L.ALaboratoryPage;
using static MASCIS.WEB.Pages.utilities.L.ALtrPage;
using static MASCIS.WEB.Pages.utilities.M.AMonthPage;
using static MASCIS.WEB.Pages.utilities.M.AMotherStatusPage;
using static MASCIS.WEB.Pages.utilities.O.AOrderStatusPage;
using static MASCIS.WEB.Pages.utilities.O.AOrderTypePage;
using MASCIS.SHARED.Models.Utility;
using static MASCIS.WEB.Pages.utilities.O.AOwnershipPage;
using static MASCIS.WEB.Pages.utilities.F.AFacilitiesPage;
using static MASCIS.WEB.Pages.utilities.F.AFacilityLevelOfCarePage;
using static MASCIS.WEB.Pages.utilities.F.AFacilityTypePage;
using static MASCIS.WEB.Pages.utilities.C.AContactPage;
using static MASCIS.WEB.Pages.utilities.C.ACyclePage;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY1MjEwM0AzMjMyMmUzMDJlMzBsbXJvWDZCZFdMell2UE9rRURmazROYUMvVEtrU2FJbmEzSXZDcDhuT3JrPQ==");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("ApiConfig")["BaseUrl"]), Timeout = TimeSpan.FromMinutes(10) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredToast();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, MascisAuthStateProvider>();
builder.Services.AddScoped<IPhysicalCountService, PhysicalCountService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();
builder.Services.AddScoped<IOrderNumberService, OrderNumberService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IRegulatoryService, RegulatoryService>();
builder.Services.AddScoped<FacilityOrderPhysicalCountHeaderAdapter>();
builder.Services.AddScoped<FacilityOrderHeaderAdapter>();
builder.Services.AddScoped<CoordinatorOrderHeaderAdapter>();
builder.Services.AddScoped<ExportApprovedOrderHeaderAdapter>();
builder.Services.AddScoped<SubmittedComplaintAdapter>();
builder.Services.AddScoped<QualityAuditAdapter>();
builder.Services.AddScoped<ContactsAdapter>();
builder.Services.AddScoped<ChangeUserPasswordAdapter>();
builder.Services.AddScoped<UserManagementAdapter>();
builder.Services.AddScoped<ProductRegistrationStatusAdapter>();
builder.Services.AddScoped<ProductVariationStatusAdapter>();
builder.Services.AddScoped<CgmpInspectionStatusAdapter>();
builder.Services.AddScoped<MarketAuthorizationStatusAdapter>();
builder.Services.AddScoped<IPharmacovigilanceService, PharmacovigilanceService>();
builder.Services.AddScoped<SADRRPatientAdapter>();
builder.Services.AddScoped<AEFIAdapter>();
builder.Services.AddScoped<ProductClassificationAdapter>();
builder.Services.AddScoped<AAdverseEventAdapter>();
builder.Services.AddScoped<AAgeGroupsAdapter>();
builder.Services.AddScoped<AAuditSectionAdapter>();
builder.Services.AddScoped<ACapaCompletionStatusAdapter>();
builder.Services.AddScoped<ACapaRegisterAdapter>();
builder.Services.AddScoped<ACDCAdapter>();
builder.Services.AddScoped<AYesNoAdapter>();
builder.Services.AddScoped<AuthRepresentativeAdapter>();
builder.Services.AddScoped<AVillageAdapter>();
builder.Services.AddScoped<AVerificationMethodAdapter>();
builder.Services.AddScoped<VariationStatusAdapter>();
builder.Services.AddScoped<TrimesterAdapter>();
builder.Services.AddScoped<TreatmentAdapter>();
builder.Services.AddScoped<ATreatmentAdapter>();
builder.Services.AddScoped<ASupplierAdapter>();
builder.Services.AddScoped<ACountyAdapter>();
builder.Services.AddScoped<ASubcountyAdapter>();
builder.Services.AddScoped<ASectorChangeAdapter>();
builder.Services.AddScoped<ASapBatchInformationAdapter>();
builder.Services.AddScoped<RegistrationStatusAdapter>();
builder.Services.AddScoped<RegionAdapter>();
builder.Services.AddScoped<PvAdapter>();
builder.Services.AddScoped<APvAdapter>();
builder.Services.AddScoped<ReleaseInstAdapter>();
builder.Services.AddScoped<AClientTyperAdapter>();
builder.Services.AddScoped<ACapaRegisterAdapter>();
builder.Services.AddScoped<ACommunicationModerAdapter>();
builder.Services.AddScoped<AComplaintActionTakenrAdapter>();
builder.Services.AddScoped<AComplaintCategoryrAdapter>();
builder.Services.AddScoped<AComplaintClassificationrAdapter>();
builder.Services.AddScoped<AComplaintConfirmationStatusrAdapter>();
builder.Services.AddScoped<AComplaintReportingGrouprAdapter>();
builder.Services.AddScoped<AComplaintStatusrAdapter>();
builder.Services.AddScoped<ACompletionTimeScalerAdapter>();
builder.Services.AddScoped<AContactTitlerAdapter>();
builder.Services.AddScoped<AContactCategoryrAdapter>();
builder.Services.AddScoped<ACountryrAdapter>();
builder.Services.AddScoped<ADeliveryZoneAdapter>();
builder.Services.AddScoped<ADistrictAdapter>();
builder.Services.AddScoped<ADoseAdapter>();
builder.Services.AddScoped<ADrugBasicUnitAdapter>();
builder.Services.AddScoped<ADrugRegimenAdapter>();
builder.Services.AddScoped<ADrugRegimenCategoryAdapter>();
builder.Services.AddScoped<ADrugRegimenClassificationAdapter>();
builder.Services.AddScoped<AGenderAdapter>();
builder.Services.AddScoped<AImplimentingPartnersAdapter>();
builder.Services.AddScoped<AInspectionStatusAdapter>();
builder.Services.AddScoped<ALabCategory1Adapter>();
builder.Services.AddScoped<ALabCategory2Adapter>();
builder.Services.AddScoped<ALabCategory2Adapter>();
builder.Services.AddScoped<ALabCategory3Adapter>();
builder.Services.AddScoped<ALaboratoryAdapter>();
builder.Services.AddScoped<ALtrAdapter>();
builder.Services.AddScoped<AMonthAdapter>();
builder.Services.AddScoped<AMotherStatusAdapter>();
builder.Services.AddScoped<AOrderStatusAdapter>();
builder.Services.AddScoped<AOrderTypeAdapter>();
builder.Services.AddScoped<AOwnershipAdapter>();
builder.Services.AddScoped<AFacilitiesAdapter>();
builder.Services.AddScoped<AFacilityLevelOfCareAdapter>();
builder.Services.AddScoped<AFacilityTypeAdapter>();
builder.Services.AddScoped<AContactsAdapter>();
builder.Services.AddScoped<ACycleAdapter>();

builder.Services.AddScoped<DocumentUploadModel>();
builder.Services.AddScoped<IPharmacovigilanceReportService, PharmacovigilanceReportService>();
builder.Services.AddScoped<FileUploadHealper>();


await builder.Build().RunAsync();
