using MASCIS.API.Interface;
using MASCIS.SHARED.DTO;
using MASCIS.SHARED.Models.ComplaintModels;
using MASCIS.SHARED.Models.PVModels;
using MASCIS.SHARED.Models.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASCIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilityService repo;
        private readonly ILogger<UtilitiesController> logger;
        public UtilitiesController(IUtilityService repo, ILogger<UtilitiesController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet("GetPrimary")]
        public async Task<PrimaryDTO> GetPrimary()
        {
            PrimaryDTO data = new PrimaryDTO();
            data.OrderStatus = repo.GetOrderStatus();
            //data.Facilities = repo.GetViewFacilities();
            data.DrugRegimen = repo.GetDrugRegimens();
            data.OrderType = repo.GetOrderType();
            data.Treatment = repo.GetTreatment();
            data.ProductCategory = repo.GetProductCategory();
            data.YesNo = await  repo.GetYesNo();
            data.ProductQuantities = await repo.GetProductQuantities();
            return data;
        }
        [HttpGet("GetProductPrimary")]
        public ProductPrimaryDataDTO GetProductPrimary()
        {
            ProductPrimaryDataDTO data = new ProductPrimaryDataDTO();
            data.Supplier = repo.GetProductSupplier();
            data.BasicUnit = repo.GetBasicUnit();
            data.Classification = repo.GetProductClassification();
            data.Category = repo.GetProductCategory();
            return data;
        }
        [HttpGet("GetFacilityPrimary")]
        public async Task<FacilityPrimaryDTO> GetFacilityPrimary()
        {
            FacilityPrimaryDTO data = new FacilityPrimaryDTO()
            {
                CdcRegion = await repo.GetCdcRegion(),
                DeliveryZone = await repo.GetDeliveryZone(),
                District = await repo.GetDistrict(),
                FacilityType = await repo.GetFacilityType(),
                ImplimentingPartner = await repo.GetImplementingPartner(),
                LevelOfCare = await repo.GetLevelOfCare(),
                Ownership = await repo.GetOwnership(),
                Contacts = await repo.GetContacts(),
            };
            return data;
        }
        [HttpGet("GetContactCategory")]
        public async Task<List<AContactCategory>?> GetContactCategory()
        {
            return await repo.GetContactCategory();
        }
        [HttpGet("GetGender")]
        public async Task<List<AGender>?> GetGender()
        {
            return await repo.GetGender();
        }
        [HttpGet("GetContact")]
        public async Task<List<AContacts>?> GetContact()
        {
            return await repo.GetContacts();
        }
        [HttpGet("GetLabCategory1")]
        public async Task<List<ALabCategory1>?> GetLabCategory1()
        {
            return await repo.GetLabCategory1();
        }
        [HttpGet("GetLabCategory2")]
        public async Task<List<ALabCategory2>?> GetLabCategory2()
        {
            return await repo.GetLabCategory2();
        }
        [HttpGet("GetLabCategory3")]
        public async Task<List<ALabCategory3>?> GetLabCategory3()
        {
            return await repo.GetLabCategory3();
        }
        [HttpGet("GetFacility")]
        public List<AFacilities>? GetFacility()
        {
            return repo.GetFacilities();
        }
        [HttpGet("GetProduct")]
        public List<AProduct>? GetProduct()
        {
            return repo.GetProduct();
        }

        [HttpPost("SaveContact")]
        public async Task<IActionResult> SaveContact(AContacts data)
        {
            try
            {
                await repo.SaveContact(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("SaveFacility")]
        public async Task<IActionResult> SaveFacility(AFacilities data)
        {
            try
            {
                await repo.SaveFacility(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("SaveProduct")]
        public async Task<IActionResult> SaveProduct(AProduct data)
        {
            try
            {
                await repo.SaveProduct(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("SaveLabCategory1")]
        public async Task<IActionResult> SaveLabCategory1(ALabCategory1 data)
        {
            try
            {
                await repo.SaveLabCategory1(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("SaveLabCategory2")]
        public async Task<IActionResult> SaveLabCategory2(ALabCategory2 data)
        {
            try
            {
                await repo.SaveLabCategory2(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("SaveLabCategory3")]
        public async Task<IActionResult> SaveLabCategory3(ALabCategory3 data)
        {
            try
            {
                await repo.SaveLabCategory3(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("SaveAContactCategory")]
        public async Task<IActionResult> SaveAContactCategory(AContactCategory data)
        {
            try
            {
                await repo.SaveAContactCategory(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("SaveAGender")]
        public async Task<IActionResult> SaveAGender(AGender data)
        {
            try
            {
                await repo.SaveAGender(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpGet("GetTreatment")]
        public List<ATreatment> GetTreatment()
        {
            return  repo.GetTreatment();
        }
        [HttpPost("SaveATreatment")]
        public async Task<IActionResult> SaveATreatment(ATreatment data)
        {
            try
            {
                await repo.SaveATreatment(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetATreatmentCategory")]
        public List<ATreatmentCategory>? GetATreatmentCategory()
        {
            return repo.GetATreatmentCategory();
        }
        [HttpPost("SaveATreatmentCategory")]
        public async Task<IActionResult> SaveATreatmentCategory(ATreatmentCategory data)
        {
            try
            {
                await repo.SaveATreatmentCategory(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetARegion")]
        public List<ARegion>? GetARegion()
        {
            return repo.GetARegion();
        }
        [HttpPost("SaveARegion")]
        public async Task<IActionResult> SaveARegion(ARegion data)
        {
            try
            {
                await repo.SaveARegion(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAProductSupplier")]
        public List<ASupplier>? GetAProductSupplier()
        {
            return repo.GetProductSupplier();
        }
        [HttpPost("SaveAProductSupplier")]
        public async Task<IActionResult> SaveAProductSupplier(ASupplier data)
        {
            try
            {

                await repo.SaveAProductSupplier(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAProductQuantities")]
        public Task<List<ASapBatchInformation>?> GetAProductQuantities()
        {
            return repo.GetProductQuantities();
        }
        [HttpPost("SaveAProductQuantities")]
        public async Task<IActionResult> SaveAProductQuantities(ASapBatchInformation data)
        {
            try
            {
                await repo.SaveAProductQuantities(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #region
        [HttpGet("GetAProductClassification")]
         public List<AProductClassification>? GetAProductClassification()
        {
            return repo.GetProductClassification();
        }

        [HttpPost("SaveAProductClassification")]
        public async Task<IActionResult> SaveAProductClassification(AProductClassification data)
        {
            try
            {
                await repo.SaveAProductClassification(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

       

        #endregion
        [HttpGet("GetAProductCategory")]

     
        public List<AProductCategory>? GetAProductCategory()
        {
            return repo.GetProductCategory();
        }
        [HttpPost("SaveAProductCategory")]
        public async Task<IActionResult> SaveAProductCategory(AProductCategory data)
        {
            try
            {
                await repo.SaveAProductCategory(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAProductBasicUnit")]
        public List<ADrugBasicUnit>? GetAProductBasicUnit()
        {
            return repo.GetBasicUnit();
        }
        [HttpPost("SaveAProductBasicUnit")]
        public async Task<IActionResult> SaveAProductBasicUnit(ADrugBasicUnit data)
        {
            try
            {
                await repo.SaveAProductBasicUnit(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAPhysicalCountStatus")]
        public Task<List<APhysicalCountStatus>?> GetAPhysicalCountStatus()
        {
            return repo.GetAPhysicalCountStatus();
        }
        [HttpPost("SaveAPhysicalCountStatus")]
        public async Task<IActionResult> SaveAPhysicalCountStatus(APhysicalCountStatus data)
        {
            try
            {
                await repo.SaveAPhysicalCountStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAOwnership")]
        public Task<List<AOwnership>?> GetAOwnership()
        {
            return repo.GetOwnership();
        }
        [HttpPost("SaveAOwnership")]
        public async Task<IActionResult> SaveAOwnership(AOwnership data)
        {
            try
            {
                await repo.SaveAOwnership(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAOrderType")]

        //AORDERTYPE
        #region
        public List<AOrderType>? GetAOrderType()
        {
            return repo.GetOrderType();
        }
        [HttpPost("SaveAOrderType")]
        public async Task<IActionResult> SaveAOrderType(AOrderType data)
        {
            try
            {
                await repo.SaveAOrderType(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion
        [HttpGet("GetAOrderStatus")]
        public List<AOrderStatus>? GetAOrderStatus()
        {
            return repo.GetOrderStatus();
        }
        [HttpPost("SaveAOrderStatus")]
        public async Task<IActionResult> SaveAOrderStatus(AOrderStatus data)
        {
            try
            {
                await repo.SaveAOrderStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAImplimentingPartners")]
        public Task<List<AImplimentingPartners>?> GetAImplimentingPartners()
        {
            return repo.GetImplementingPartner();
        }
        [HttpPost("SaveAImplimentingPartners")]
        public async Task<IActionResult> SaveAImplimentingPartners(AImplimentingPartners data)
        {
            try
            {
                await repo.SaveAImplimentingPartners(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAFacilityType")]
        public Task<List<AFacilityType>?> GetAFacilityType()
        {
            return repo.GetFacilityType();
        }
        [HttpPost("SaveAFacilityType")]
        public async Task<IActionResult> SaveAFacilityType(AFacilityType data)
        {
            try
            {
                await repo.SaveAFacilityType(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetAFacilityLevelOfCare")]
        public Task<List<AFacilityLevelOfCare>?> GetAFacilityLevelOfCare()
        {
            return repo.GetLevelOfCare();
        }
        [HttpPost("SaveAFacilityLevelOfCare")]
        public async Task<IActionResult> SaveAFacilityLevelOfCare(AFacilityLevelOfCare data)
        {
            try
            {
                await repo.SaveAFacilityLevelOfCare(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetADrugRegimenClassification")]
        public Task<List<ADrugRegimenClassification>?> GetADrugRegimenClassification()
        {
            return repo.GetADrugRegimenClassification();
        }
        [HttpPost("SaveADrugRegimenClassification")]
        public async Task<IActionResult> SaveADrugRegimenClassification(ADrugRegimenClassification data)
        {
            try
            {
                await repo.SaveADrugRegimenClassification(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //drug reg cat
        #region
        [HttpGet("GetADrugRegimenCategory")]
        public Task<List<ADrugRegimenCategory>?> GetADrugRegimenCategory()
        {
            return repo.GetADrugRegimenCategory();
        }
        [HttpPost("SaveADrugRegimenCategory")]
        public async Task<IActionResult> SaveADrugRegimenCategory(ADrugRegimenCategory data)
        {
            try
            {
                await repo.SaveADrugRegimenCategory(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        //drug a drug
        #region
        [HttpGet("GetADrugRegimen")]
        public List<ADrugRegimen>? GetADrugRegimen()
        {
            return repo.GetDrugRegimens();
        }
        [HttpPost("SaveADrugRegimen")]
        public async Task<IActionResult> SaveADrugRegimen(ADrugRegimen data)
        {
            try
            {
                await repo.SaveADrugRegimen(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        //District
        #region
        [HttpGet("GetADistrict")]
          public Task<List<ADistrict>?> GetADistrict()
        {
            return repo.GetDistrict();
        }
        [HttpPost("SaveADistrict")]
        public async Task<IActionResult> SaveADistrict(ADistrict data)
        {
            try
            {
                await repo.SaveADistrict(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //Delivery zone
        #region
        [HttpGet("GetADeliveryZone")]
        public async Task<List<ADeliveryZone>?> GetADeliveryZone()
        {
            return await repo.GetDeliveryZone();
        }
        [HttpPost("SaveADeliveryZone")]
        public async Task<IActionResult> SaveADeliveryZone(ADeliveryZone data)
        {
            try
            {
                await repo.SaveDeliveryZone(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion
        //cdcregion
        #region
        [HttpGet("GetACdcregion")]
        public Task<List<ACdcregion>?> GetACdcregion()
        {
            return repo.GetCdcRegion();
        }
        [HttpPost("SaveACdcregion")]
        public async Task<IActionResult> SaveACdcregion(ACdcregion data)
        {
            try
            {
                await repo.SaveCdcregion(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion
        //[HttpGet("GetLogos")]
        //public List<ImageDTO>? GetLogos()
        //{
        //    return repo.GetLogos();
        //}
        [HttpGet("GetCycle")]
        //public List<ACycle>? GetCycle()
        //{
        //    return repo.GetCycle();
        //}
        [HttpGet("GetMonth")]
        public List<AMonth>? GetMonth()
        {
            return repo.GetMonth();
        }
        [HttpPost("SaveCycle")]
        public async Task<IActionResult> SaveCycle(ACycle data)
        {
            try
            {
                await repo.SaveCycle(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("GetTrimester")]
        public async Task<List<ATrimester>?> GetTrimester()
        {
            return await repo.GetTrimester();
        }

        [HttpGet("GetSADRROutcome")]
        public async Task<List<SadrrOutcome>?> GetSADRROutcome()
        {
            return await repo.GetSADRROutcome();
        }

        [HttpGet("GetAEFIOutcome")]
        public async Task<List<SadrrOutcome>?> GetAEFIOutcome()
        {
            return await repo.GetAEFIOutcome();
        }

        [HttpGet("GetReactionSeriousness")]
        public async Task<List<SadrrReaction>?> GetReactionSeriousness()
        {
            return await repo.GetReactionSeriousness();
        }

        [HttpGet("GetMotherStatus")]
        public async Task<List<AMotherStatus>?> GetMotherStatus()
        {
            return await repo.GetMotherStatus();
        }
        //age groups
        #region

        [HttpGet("GetAgeGroup")]
        public async Task<List<AAgeGroups>?> GetAgeGroup()
        {
            return await repo.GetAgeGroup();
        }
        [HttpPost("SaveAAgeGroups")]
        public async Task<IActionResult> SaveAAdverseEvent(AAgeGroups data)
        {
            try
            {
                await repo.SaveAAgeGroups(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        [HttpGet("GetDose")]
        public async Task<List<ADose>?> GetDose()
        {
            return await repo.GetDose();
        }

        //adverse
        #region 

        [HttpGet("GetAdverseEvent")]
        public async Task<List<AAdverseEvent>?> GetAdverseEvent()
        {
            return await repo.GetAdverseEvent();
        }
        [HttpPost("SaveAAdverseEvent")]
        public async Task<IActionResult> SaveAAdverseEvent(AAdverseEvent data)
        {
            try
            {
                await repo.SaveAAdverseEvent(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        //AuditSAection
        #region

        [HttpGet("GetAuditSection")]
        public async Task<List<AAuditSection>?> GetAuditSection()
        {
            return await repo.GetAuditSection();
        }
        [HttpPost("SaveAuditSection")]
        public async Task<IActionResult> SaveAuditSection(AAuditSection data)
        {
            try
            {
                await repo.SaveAuditSection(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion
        //AuditSAection
        #region

        [HttpGet("GetAAuthorizedRepresentative")]
        public async Task<List<AAuthorizedRepresentative>?> GetAuthorizedRep()
        {
            return await repo.GetAuthorizedRep();
        }
        [HttpPost("SaveAuthorizedRep")]
        public async Task<IActionResult> SaveAuthorizedRep(AAuthorizedRepresentative data)
        {
            try
            {
                await repo.SaveAuthorizedRep(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        [HttpGet("GetPVStatus")]
        public async Task<List<APvsatus>?> GetPVStatus()
        {
            return await repo.GetPVStatus();
        }

        [HttpGet("GetReportingType")]
        public async Task<List<APvreportingType>?> GetReportingType()
        {
            return await repo.GetReportingType();
        }

        //county
        #region
        [HttpGet("GetACounty")]
        public async Task<List<ACounty>?> GetACounty()
        {
            return await repo.GetACounty();
        }

        [HttpPost("SaveACounty")]
        public async Task<IActionResult> SaveACounty(ACounty data)
        {
            try
            {
                await repo.SaveACounty(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //subcounty
        #region
        [HttpGet("GetASubcounty")]
        public async Task<List<ASubcounty>?> GetASubcounty()
        {
            return await repo.GetASubcounty();
        }

        [HttpPost("SaveASubcounty")]
        public async Task<IActionResult> SaveASubcounty(ASubcounty data)
        {
            try
            {
                await repo.SaveASubcounty(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion


        ////PVSTATUS
        //[HttpPost("SavePVStatus")]
        //public async Task<IActionResult> SavePVStatus(APvsatus data)
        //{
        //    try
        //    {
        //        await repo.SavePVStatus(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok();
        //}


        //registration status
        #region

        [HttpGet("GetARegistrationStatus")]
        public async Task<List<ARegistrationStatus>?> GetARegistrationStatus()
        {
            return await repo.GetARegistrationStatus();
        }

        [HttpPost("SaveARegistrationStatus")]
        public async Task<IActionResult> SaveARegistrationStatus(ARegistrationStatus data)
        {
            try
            {
                await repo.SaveARegistrationStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //releaseinstruction
        #region

        [HttpGet("GetReleaseInstruction")]
        public async Task<List<AReleaseInstruction>?> GetReleaseInstruction()
        {
            return await repo.GetReleaseInstruction();
        }

        [HttpPost("SaveReleaseInstruction")]
        public async Task<IActionResult> SaveReleaseInstruction(AReleaseInstruction data)
        {
            try
            {
                await repo.SaveReleaseInstruction(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //ASAPBATCHAPI
        #region

        [HttpGet("GetASapBatchInformation")]
        public async Task<List<ASapBatchInformation>?> GetASapBatchInformation()
        {
            return await repo.GetASapBatchInformation();
        }

        [HttpPost("SaveASapBatchInformation")]
        public async Task<IActionResult> SaveASapBatchInformation(ASapBatchInformation data)
        {
            try
            {
                await repo.SaveASapBatchInformation(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //sectorchange
        #region
        [HttpGet("GetASectorChange")]
        public async Task<List<ASectorChange>?> GetASectorChange()
        {
            return await repo.GetASectorChange();
        }

        [HttpPost("SaveASectorChange")]
        public async Task<IActionResult> SaveASectorChange(ASectorChange data)
        {
            try
            {
                await repo.SaveASectorChange(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //supplier
        #region
        [HttpGet("GetASupplier")]
        public async Task<List<ASupplier>?> GetASupplier()
        {
            return await repo.GetASupplier();
        }

        [HttpPost("SaveASupplier")]
        public async Task<IActionResult> SaveASupplier(ASupplier data)
        {
            try
            {
                await repo.SaveASupplier(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //trimister
        #region

        //[HttpGet("GetTrimester")]
        //public async Task<List<ATrimester>?> GetTrimester()
        //{
        //    return await repo.GetTrimester();
        // }
        [HttpPost("SaveTrimester")]
        public async Task<IActionResult> SaveTrimester(ATrimester data)
        {
            try
            {
                await repo.SaveTrimester(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        //capacompletion status
        #region

        [HttpGet("GetACapaCompletionStatus")]
        public async Task <List<ACapaCompletionStatus>?> GetACapaCompletionStatus()
        {
            return await repo.GetACapaCompletionStatus();
        }
        [HttpPost("SaveACapaCompletionStatus")]
        public async Task<IActionResult> SaveACapaCompletionStatus(ACapaCompletionStatus data)
        {
            try
            {
                await repo.SaveACapaCompletionStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
#endregion
        //capa register status
        #region

        [HttpGet("GetACapaRegisterStatus")]
        public async Task<List<ACapaRegisterStatus>?> GetACapaRegisterStatus()
        {
            return await repo.GetACapaRegisterStatus();
        }
        [HttpPost("SaveACapaRegisterStatus")]
        public async Task<IActionResult> SaveACapaRegisterStatus(ACapaRegisterStatus data)
        {
            try
            {
                await repo.SaveACapaRegisterStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        //varimethod
        #region

        [HttpGet("GetVariationStatus")]
        public async Task<List<AVariationStatus>?> GetVariation()
        {
            return await repo.GetVariation();
        }

        [HttpPost("SaveVariationStatus")]
        public async Task<IActionResult> SaveVariation(AVariationStatus  data)
        {
            try
            {
                await repo.SaveVariation(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //verimethod
        #region

        [HttpGet("GetVerificationMethod")]
        public async Task<List<AVerificationMethod>?> GetVerificationMethod()
        {
            return await repo.GetVerificationMethod();
        }

        [HttpPost("SaveVerificationMethod")]
        public async Task<IActionResult> SaveVerificationMethod(AVerificationMethod data)
        {
            try
            {
                await repo.SaveVerificationMethod(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //reporting type
        #region
        [HttpGet("GetAPVReporting")]
        public async Task<List<APvreportingType>?> GetAPVReporting()
        {
            return await repo.GetAPVReporting();
        }

        [HttpPost("SaveAPVReporting")]
        public async Task<IActionResult> SaveAPVReporting(APvreportingType data)
        {
            try
            {
                await repo.SaveAPVReporting(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

     

        //Aclientype
        #region

        [HttpGet("GetAClientType")]
        public async Task<List<AClientType>?> GetAClientType()
        {
            return await repo.GetAClientType();
        }

        [HttpPost("SaveAClientType")]
        public async Task<IActionResult> SaveAClientType(AClientType data)
        {
            try
            {
                await repo.SaveAClientType(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Acommunicationtype
        #region

        [HttpGet("GetACommunicationMode")]
        public async Task<List<ACommunicationMode>?> GetACommunicationMode()
        {
            return await repo.GetACommunicationMode();
        }

        [HttpPost("SaveACommunicationMode")]
        public async Task<IActionResult> SaveACommunicationMode(ACommunicationMode data)
        {
            try
            {
                await repo.SaveACommunicationMode(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Acommunicationtype
        #region

        [HttpGet("GetAComplaintActionTaken")]
        public async Task<List<AComplaintActionTaken>?> GetAComplaintActionTaken()
        {
            return await repo.GetAComplaintActionTaken();
        }

        [HttpPost("SaveAComplaintActionTaken")]
        public async Task<IActionResult> SaveAComplaintActionTaken(AComplaintActionTaken data)
        {
            try
            {
                await repo.SaveAComplaintActionTaken(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //Acomplaintcategory
        #region

        [HttpGet("GetAComplaintCategory")]
        public async Task<List<AComplaintCategory>?> GetAComplaintCategory()
        {
            return await repo.GetAComplaintCategory();
        }

        [HttpPost("SaveAComplaintCategory")]
        public async Task<IActionResult> SaveAComplaintCategory(AComplaintCategory data)
        {
            try
            {
                await repo.SaveAComplaintCategory(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Acomplaitclassification
        #region

        [HttpGet("GetAComplaintClassification")]
        public async Task<List<AComplaintClassification>?> GetAComplaintClassification()
        {
            return await repo.GetAComplaintClassification();
        }

        [HttpPost("SaveAComplaintClassification")]
        public async Task<IActionResult> SaveAComplaintClassification(AComplaintClassification data)
        {
            try
            {
                await repo.SaveAComplaintClassification(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Acomplaitconfirmationstatus
        #region

        [HttpGet("GetAComplaintConfirmationStatus")]
        public async Task<List<AComplaintConfirmationStatus>?> GetAComplaintConfirmationStatus()
        {
            return await repo.GetAComplaintConfirmationStatus();
        }

        [HttpPost("SaveAComplaintConfirmationStatus")]
        public async Task<IActionResult> SaveAComplaintConfirmationStatus(AComplaintConfirmationStatus data)
        {
            try
            {
                await repo.SaveAComplaintConfirmationStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //AcomplaitREPORTINGGROUP
        #region

        [HttpGet("GetAComplaintReportingGroup")]
        public async Task<List<AComplaintReportingGroup>?> GetAComplaintReportingGroup()
        {
            return await repo.GetAComplaintReportingGroup();
        }

        [HttpPost("SaveAComplaintReportingGroup")]
        public async Task<IActionResult> SaveAComplaintReportingGroup(AComplaintReportingGroup data)
        {
            try
            {
                await repo.SaveAComplaintReportingGroup(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Acomplaitstatus
        #region

        [HttpGet("GetAComplaintStatus")]
        public async Task<List<AComplaintStatus>?> GetAComplaintStatus()
        {
            return await repo.GetAComplaintStatus();
        }

        [HttpPost("SaveAComplaintStatus")]
        public async Task<IActionResult> SaveAComplaintStatus(AComplaintStatus data)
        {
            try
            {
                await repo.SaveAComplaintStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //Acomplaitstatus
        #region

        [HttpGet("GetACompletionTimeScale")]
        public async Task<List<ACompletionTimeScale>?> GetACompletionTimeScale()
        {
            return await repo.GetACompletionTimeScale();
        }

        [HttpPost("SaveACompletionTimeScale")]
        public async Task<IActionResult> SaveACompletionTimeScale(ACompletionTimeScale data)
        {
            try
            {
                await repo.SaveACompletionTimeScale(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //AcontactTitle
        #region

        [HttpGet("GetAContactTitle")]
        public async Task<List<AContactTitle>?> GetAContactTitle()
        {
            return await repo.GetAContactTitle();
        }

        [HttpPost("SaveAContactTitle")]
        public async Task<IActionResult> SaveAContactTitle(AContactTitle data)
        {
            try
            {
                await repo.SaveAContactTitle(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //Acountry
        #region

        [HttpGet("GetACountry")]
        public async Task<List<ACountry>?> GetACountry()
        {
            return await repo.GetACountry();
        }

        [HttpPost("SaveACountry")]
        public async Task<IActionResult> SaveAContactTitle(ACountry data)
        {
            try
            {
                await repo.SaveACountry(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //Acountry
        #region

      
        #endregion

        //adose
        [HttpPost("SaveDose")]
        public async Task<IActionResult> SaveDose(ADose data)
        {
            try
            {
                await repo.SaveDose(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //Acountry
        #region

        [HttpGet("GetAInspectionStatus")]
        public async Task<List<AInspectionStatus>?> GetAInspectionStatus()
        {
            return await repo.GetAInspectionStatus();
        }

        [HttpPost("SaveAInspectionStatus")]
        public async Task<IActionResult> SaveAInspectionStatus(AInspectionStatus data)
        {
            try
            {
                await repo.SaveAInspectionStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Alaboratort
        #region

        [HttpGet("GetLab")]
        public async Task<List<ALaboratory>?> GetLab()
        {
            return await repo.GetLab();
        }

        [HttpPost("SaveLab")]
        public async Task<IActionResult> SaveLab(ALaboratory data)
        {
            try
            {
                await repo.SaveLab(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //Altr
        #region

        [HttpGet("GetLtr")]
        public async Task<List<ALtr>?> GetLtr()
        {
            return await repo.GetLtr();
        }

        [HttpPost("SaveLtr")]
        public async Task<IActionResult> SaveLtr(ALtr data)
        {
            try
            {
                await repo.SaveLtr(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //AMonth
        #region

        [HttpGet("GetAMonth")]
        public async Task<List<AMonth>?> GetAMonth()
        {
            return await repo.GetAMonth();
        }

        [HttpPost("SaveAMonth")]
        public async Task<IActionResult> SaveAMonth(AMonth data)
        {
            try
            {
                await repo.SaveAMonth(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion
        //motherstatus
        [HttpPost("SaveAMotherStatus")]
        public async Task<IActionResult> SaveAMotherStatus(AMotherStatus data)
        {
            try
            {
                await repo.SaveAMotherStatus(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //ACYCLE
        #region

        [HttpGet("GetACycle")]
        public async Task<List<ACycle>?> GetACycle()
        {
            return await repo.GetACycle();
        }

        [HttpPost("SaveACycle")]
        public async Task<IActionResult> SaveACycle(ACycle data)
        {
            try
            {
                await repo.SaveACycle(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //AVillage
        #region

        [HttpGet("GetAVillage")]
        public async Task<List<AVillage>?> GetAVillage()
        {
            return await repo.GetAVillage();
        }

        [HttpPost("SaveAVillage")]
        public async Task<IActionResult> SaveAVillage(AVillage data)
        {
            try
            {
                await repo.SaveAVillage(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

        //ayesno
        #region

        [HttpGet("GetYesNo")]
        public async  Task<List<AYesNo>?> GetYesNo()
        {
            return await  repo.GetYesNo();
        }

        [HttpPost("SaveYesNo")]
        public async Task<IActionResult> SaveYesNo(AYesNo data)
        {
            try
            {
                await repo.SaveYesNo(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        #endregion

    }
}
