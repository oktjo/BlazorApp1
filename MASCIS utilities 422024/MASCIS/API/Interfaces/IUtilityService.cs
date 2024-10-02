using MASCIS.SHARED.DTO;
using MASCIS.SHARED.Models.ComplaintModels;
using MASCIS.SHARED.Models.PVModels;
using MASCIS.SHARED.Models.Utility;

namespace MASCIS.API.Interface
{
    public interface IUtilityService
    {
        List<ADrugRegimen> GetDrugRegimens();
       // List<ACycle> GetCycle();
      
        List<AMonth> GetMonth();
        List<AFacilities>? GetFacilities();
        List<AOrderStatus>? GetOrderStatus();
        List<AOrderType>? GetOrderType();
       
        //List<ViewFacilities>? GetViewFacilities();
        List<AProduct>? GetProduct();
        List<AProductCategory>? GetProductCategory();
        List<AProductClassification>? GetProductClassification();
        
        List<ADrugBasicUnit>? GetBasicUnit();
        List<ASupplier>? GetProductSupplier();
        Task<List<AContacts>?> GetContacts();
        Task<List<AContactCategory>?> GetContactCategory();
        Task<List<AFacilityType>?> GetFacilityType();
        Task<List<ADeliveryZone>?> GetDeliveryZone();
        Task<List<AImplimentingPartners>?> GetImplementingPartner();
        Task<List<ADistrict>?> GetDistrict();
        Task<List<AFacilityLevelOfCare>?> GetLevelOfCare();
        Task<List<AOwnership>?> GetOwnership();
      
        Task<List<AGender>?> GetGender();
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


      
        Task SaveAContactCategory(AContactCategory data);
        Task SaveDeliveryZone(ADeliveryZone data);
        Task SaveADistrict(ADistrict data);
        Task SaveADrugRegimen(ADrugRegimen data);
        Task SaveADrugRegimenCategory(ADrugRegimenCategory data);
        Task<List<ADrugRegimenCategory>?> GetADrugRegimenCategory();
        Task SaveADrugRegimenClassification(ADrugRegimenClassification data);
        Task<List<ADrugRegimenClassification>?> GetADrugRegimenClassification();
        Task SaveAFacilityLevelOfCare(AFacilityLevelOfCare data);
        Task SaveAFacilityType(AFacilityType data);
        Task SaveAGender(AGender data);
        Task SaveAImplimentingPartners(AImplimentingPartners data);
        Task SaveAOrderStatus(AOrderStatus data);
        Task SaveAOrderType(AOrderType data);
        Task SaveAOwnership(AOwnership data);
        Task SaveAPhysicalCountStatus(APhysicalCountStatus data);
        Task<List<APhysicalCountStatus>?> GetAPhysicalCountStatus();
        Task SaveAProductBasicUnit(ADrugBasicUnit data);
        Task SaveAProductCategory(AProductCategory data);
        Task SaveAProductClassification(AProductClassification data);
        Task SaveAProductQuantities(ASapBatchInformation data);
        Task SaveAProductSupplier(ASupplier data);
        Task SaveARegion(ARegion data);
        List<ARegion> GetARegion();

        //treatment
        Task SaveATreatment(ATreatment data);
       List<ATreatment>? GetTreatment();
       
        Task SaveCycle(ACycle data);
        Task SaveATreatmentCategory(ATreatmentCategory data);
        List<ATreatmentCategory>? GetATreatmentCategory();

        Task<List<ATrimester>?> GetTrimester();
        Task<List<SadrrOutcome>?> GetSADRROutcome();
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
        Task<List<AAuthorizedRepresentative>?> GetAuthorizedRep();
        Task SaveAuthorizedRep(AAuthorizedRepresentative data);
        Task<List<ACapaCompletionStatus>?> GetACapaCompletionStatus();
        Task SaveACapaCompletionStatus(ACapaCompletionStatus data); 
        Task<List<ACapaRegisterStatus>?> GetACapaRegisterStatus();
        Task SaveACapaRegisterStatus(ACapaRegisterStatus data);
        Task<List<ACdcregion>?> GetCdcRegion();
        Task SaveCdcregion(ACdcregion data);

        //Task SaveAYesNo(AYesNo data);
        //List<AYesNo> GetYesNo();
        //  Task SaveVillage(AVillage data);
        //Task  <List<AVillage>> GetVillage();
        Task SaveVerificationMethod(AVerificationMethod data);
        Task<List<AVerificationMethod>?> GetVerificationMethod();
        Task SaveVariation(AVariationStatus data);
        Task<List<AVariationStatus>?> GetVariation();
        Task SaveTrimester(ATrimester data);
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
        Task<List<AOrderStatus>?> GetAOrderStatus();
        //Task SaveAOrderStatus(AOrderStatus data);

        Task<List<AOwnership>?> GetAOwnership();
        //Task SaveAOwnership(AOwnership data);

        Task SaveACycle(ACycle data);
        Task<List<ACycle>?> GetACycle();
        Task SaveAVillage(AVillage data);
        Task<List<AVillage>?> GetAVillage();
        Task SaveYesNo(AYesNo data);
        Task<List<AYesNo>?> GetYesNo();

    }
}
