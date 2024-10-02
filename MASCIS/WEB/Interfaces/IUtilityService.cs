using MASCIS.SHARED.DTO;
using MASCIS.SHARED.Models.PVModels;
using MASCIS.SHARED.Models.Utility;

namespace MASCIS.WEB.Interface
{
    public interface IUtilityService
    {
        //Task GetLogos();
        Task GetCycle();
        Task GetMonth();
        Task<List<ACycle>> GetLocalCycle();
        Task<List<AMonth>> GetLocalMonth();
        //Task<List<ImageDTO>> GetLocalLogos();
        Task GetPrimaryData();
        Task<List<ADrugRegimen>> GetDrugRegimens();
        //Task<List<ViewFacilities>>? GetViewFacilities();
        Task<List<AOrderStatus>?> GetAOrderStatus();
        
        Task<List<AOrderType>?> GetOrderType();

        Task<List<AProductCategory>> GetProductCategory();
        Task<List<AProduct>?> GetProduct();
        Task<List<AContacts>?> GetContacts();
        Task<List<AFacilities>?> GetFacilities();
        Task<List<AContactCategory>?> GetContactCategory();
        Task SaveAContactCategory(AContactCategory data);
        Task<List<AGender>?> GetGender();
        Task<FacilityPrimaryDTO?> GetFacilityPrimaryData();
        Task<ProductPrimaryDataDTO?> GetProductPrimaryData();
        Task<List<ASapBatchInformation>?> GetProductQuantities();
        Task<List<ALabCategory1>?> GetLabCategory1();
        Task<List<ALabCategory2>?> GetLabCategory2();
        Task<List<ALabCategory3>?> GetLabCategory3();
        Task SaveFacility(AFacilities data);
        Task SaveContact(AContacts data);
        Task SaveProduct(AProduct data);
        Task SaveLabCategory1(ALabCategory1 data);
        Task SaveLabCategory2(ALabCategory2 data);
        Task SaveLabCategory3(ALabCategory3 data);

        Task SaveAProductClassification(AProductClassification data);
      
        Task<List<AProductClassification>>? GetProductClassification();
       
        Task SaveAProductQuantities(ASapBatchInformation data);

        Task SaveAProductSupplier(ASupplier data);
        Task<List<ASupplier>>? GetProductSupplier();
        Task SaveARegion(ARegion data);
        Task<List<ARegion>?> GetARegion();
        //TREATMENT
        Task SaveATreatment(ATreatment data);
        Task <List<ATreatment>>? GetTreatment();
        Task SaveATreatmentCategory(ATreatmentCategory data);
        Task<List<ATreatmentCategory>?> GetATreatmentCategory();
        //cdc
        #region
        Task SaveCdcregion(ACdcregion data);
        Task<List<ACdcregion>?> GetCdcRegion();
#endregion
 
        Task SaveDeliveryZone(ADeliveryZone data);
        Task<List<ADeliveryZone>?> GetDeliveryZone();
        Task SaveADistrict(ADistrict data);
        Task<List<ADistrict>?> GetDistrict();
        Task SaveADrugRegimen(ADrugRegimen data);
        Task SaveADrugRegimenCategory(ADrugRegimenCategory data);
        Task<List<ADrugRegimenCategory>?> GetADrugRegimenCategory();
        Task SaveADrugRegimenClassification(ADrugRegimenClassification data);
        Task<List<ADrugRegimenClassification>?> GetADrugRegimenClassification();
        Task SaveAFacilityLevelOfCare(AFacilityLevelOfCare data);
        Task<List<AFacilityLevelOfCare>?> GetLevelOfCare();
        Task SaveAFacilityType(AFacilityType data);
        Task<List<AFacilityType>?> GetFacilityType();
        Task SaveAGender(AGender data);
        Task SaveAImplimentingPartners(AImplimentingPartners data);
        Task<List<AImplimentingPartners>?> GetImplementingPartner();
        Task SaveAOrderStatus(AOrderStatus data);
        Task SaveAOrderType(AOrderType data);
        Task SaveAOwnership(AOwnership data);
        Task<List<AOwnership>?> GetOwnership();
        Task SaveAPhysicalCountStatus(APhysicalCountStatus data);
        Task<List<APhysicalCountStatus>?> GetAPhysicalCountStatus();
        Task SaveAProductBasicUnit(ADrugBasicUnit data);
        Task<List<ADrugBasicUnit>>? GetBasicUnit();
        //Task SaveBasicUnit(ADrugBasicUnit data);

        Task SaveAProductCategory(AProductCategory data);
        Task SaveCycle(ACycle data);
        
        Task<List<SadrrOutcome>?> GetOutcome();
        Task<List<SadrrOutcome>?> GetAEFIOutcome();
        Task<List<SadrrReaction>?> GetReactionSeriousness();
        Task<List<AMotherStatus>?> GetMotherStatus();
        Task<List<AAgeGroups>?> GetAgeGroup();
        Task<List<ADose>?> GetDose();
        Task<List<AAdverseEvent>?> GetAdverseEvent();
        
      
        Task<List<APvreportingType>?> GetReportingType();

        Task SaveAAdverseEvent(AAdverseEvent data);
        Task SaveAAgeGroups(AAgeGroups data);
        Task<List<AAuditSection>?> GetAuditSection();
        Task SaveAuditSection(AAuditSection data);
        Task <List<AAuthorizedRepresentative>?> GetAuthorizedRep();
        Task SaveAuthorizedRep(AAuthorizedRepresentative data);

        Task<List<ACapaCompletionStatus>?> GetACapaCompletionStatus();
        Task SaveACapaCompletionStatus(ACapaCompletionStatus data);
        Task<List<ACapaRegisterStatus>?> GetACapaRegisterStatus();
        Task SaveACapaRegisterStatus(ACapaRegisterStatus data);

        
       
        //Task SaveAYesNo(AYesNo data);
        //  Task SaveVillage(AVillage data);
        //Task <List<AVillage>?> GetVillage();
        Task SaveVerificationMethod(AVerificationMethod data);
        Task<List<AVerificationMethod>> GetVerificationMethod();
        Task SaveVariation(AVariationStatus data);
        Task<List<AVariationStatus>?> GetVariation();
        Task SaveTrimester(ATrimester data);
        Task<List<ATrimester>?> GetTrimester();
        Task SaveASupplier(ASupplier data);
        Task<List<ASupplier>?> GetASupplier();
        Task SaveACounty(ACounty data);
        Task<List<ACounty>?> GetACounty();
        Task SaveASubcounty(ASubcounty data);
        Task<List<ASubcounty>?> GetASubcounty();
        Task SaveASectorChange(ASectorChange data);
        Task<List<ASectorChange>?> GetASectorChange();
        Task SaveASapBatchInformation(ASapBatchInformation data);
        Task<List<ASapBatchInformation>?> GetASapBatchInformation();
        Task SaveReleaseInstruction(AReleaseInstruction data);
        Task<List<AReleaseInstruction>?> GetReleaseInstruction();
        Task SaveARegistrationStatus(ARegistrationStatus data);
        Task<List<ARegistrationStatus>?> GetARegistrationStatus();
        Task<List<APvsatus>?> GetPVStatus();
        Task SavePVStatus(APvsatus data);
        Task<List<APvreportingType>?> GetAPVReporting();
        Task SaveAPVReporting(APvreportingType data);

        Task<List<AClientType>?> GetAClientType();
        Task SaveAClientType(AClientType data);
        Task<List<ACommunicationMode>?> GetACommunicationMode();
        Task SaveACommunicationMode(ACommunicationMode data);
        Task<List<AComplaintActionTaken>?> GetAComplaintActionTaken();
        Task SaveAComplaintActionTaken(AComplaintActionTaken data);
        Task<List<AComplaintCategory>?> GetAComplaintCategory();
        Task SaveAComplaintCategory(AComplaintCategory data);
        Task<List<AComplaintClassification>?> GetAComplaintClassification();
        Task SaveAComplaintClassification(AComplaintClassification data);
        Task<List<AComplaintConfirmationStatus>?> GetAComplaintConfirmationStatus();
        Task SaveAComplaintConfirmationStatus(AComplaintConfirmationStatus data);
        Task<List<AComplaintReportingGroup>?> GetAComplaintReportingGroup();
        Task SaveAComplaintReportingGroup(AComplaintReportingGroup data);
        Task<List<AComplaintStatus>?> GetAComplaintStatus();
        Task SaveAComplaintStatus(AComplaintStatus data);
        Task<List<ACompletionTimeScale>?> GetACompletionTimeScale();
        Task SaveACompletionTimeScale(ACompletionTimeScale data);
        Task<List<AContactTitle>?> GetAContactTitle();
        Task SaveAContactTitle(AContactTitle data);
        Task<List<ACountry>?> GetACountry();
        Task SaveACountry(ACountry data);
        Task SaveDose(ADose data);
        Task<List<ADeliveryZone>?> GetADeliveryZone();
        Task SaveADeliveryZone(ADeliveryZone data);

        Task<List<AInspectionStatus>?> GetAInspectionStatus();
        Task SaveAInspectionStatus(AInspectionStatus data);
        Task<List<ALaboratory>?> GetLab();
        Task SaveLab(ALaboratory data);
        Task<List<ALtr>?> GetLtr();
        Task SaveLtr(ALtr data);
        Task<List<AMonth>?> GetAMonth();
        Task SaveAMonth(AMonth data);
        Task SaveAMotherStatus(AMotherStatus data);
        //Task<List<AOrderStatus>?> GetOrderStatus();
        //Task SaveAOrderStatus(AOrderStatus data);

        Task<List<AOwnership>?> GetAOwnership();
        //Task SaveOwnership(AOwnership data);
        Task SaveACycle(ACycle data);
        Task<List<ACycle>?> GetACycle();
        Task SaveAVillage(AVillage data);
        Task<List<AVillage>?> GetAVillage();
        Task SaveYesNo(AYesNo data);
        Task<List<AYesNo>?> GetYesNo();
    }
}
