using Blazored.LocalStorage;
using Blazored.Toast.Services;
using MASCIS.SHARED.DTO;
using MASCIS.SHARED.Models.ComplaintModels;
using MASCIS.SHARED.Models.PVModels;
using MASCIS.SHARED.Models.Utility;
using MASCIS.WEB.Interface;
using System.Text.Json;

namespace MASCIS.WEB.Repository
{
    public class UtilityService : IUtilityService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly IToastService toastService;
        private readonly ILocalStorageService LocalStorage;
        public UtilityService(HttpClient httpClient, IToastService toastService
            , ILocalStorageService LocalStorage)
        {
            _httpClient = httpClient;
            this.toastService = toastService;
            this.LocalStorage = LocalStorage;
        }
        public async Task<List<ADrugRegimen>> GetDrugRegimens()
        {
            List<ADrugRegimen> data = new List<ADrugRegimen>();
            data = await LocalStorage.GetItemAsync<List<ADrugRegimen>>("DrugRegimen");
            return data;
        }
        public async Task<List<AFacilityType>?> GetFacilityType()
        {
            List<AFacilityType>? data = new List<AFacilityType>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAFacilityType");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AFacilityType>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        //public async Task<List<ViewFacilities>>? GetViewFacilities()
        //{
        //    List<ViewFacilities> data = new List<ViewFacilities>();
        //    data = await LocalStorage.GetItemAsync<List<ViewFacilities>>("Facilities");
        //    return data;
        //}

        public async Task<List<AOrderStatus>?> GetOrderStatus()
        {
            List<AOrderStatus> data = new List<AOrderStatus>();
            data = await LocalStorage.GetItemAsync<List<AOrderStatus>>("OrderStatus");
            return data;
        }

        public async Task<List<AOrderType>>? GetOrderType()
        {
            List<AOrderType> data = new List<AOrderType>();
            data = await LocalStorage.GetItemAsync<List<AOrderType>>("OrderType");
            return data;
        }

        public async Task GetPrimaryData()
        {
            PrimaryDTO? data = new PrimaryDTO();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetPrimary");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonSerializer.Deserialize<PrimaryDTO>(content, _options);
                    if (data != null)
                    {
                        if (data.OrderStatus != null && data.OrderStatus.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("OrderStatus", data.OrderStatus);
                        }
                        //if (data.Facilities != null && data.Facilities.Count > 0)
                        //{
                        //    await LocalStorage.SetItemAsync("Facilities", data.Facilities);
                        //}
                        if (data.DrugRegimen != null && data.DrugRegimen.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("DrugRegimen", data.DrugRegimen);
                        }
                        if (data.OrderType != null && data.OrderType.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("OrderType", data.OrderType);
                        }
                        if (data.Treatment != null && data.Treatment.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("Treatment", data.Treatment);
                        }
                        if (data.ProductCategory != null && data.ProductCategory.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("ProductCategory", data.ProductCategory);
                        }
                        if (data.ProductQuantities != null && data.ProductQuantities.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("ProductQuantities", data.ProductQuantities);
                        }
                        if (data.YesNo != null && data.YesNo.Count > 0)
                        {
                            await LocalStorage.SetItemAsync("YesNo", data.YesNo);
                        }
                    }
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        //Treatrment
        public async Task<List<ATreatment>> GetTreatment()
        {
            List<ATreatment> data = new List<ATreatment>();
            data = await LocalStorage.GetItemAsync<List<ATreatment>>("Treatment");
            return data;
        }
         public async Task SaveATreatment(ATreatment data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveATreatment", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task<List<AProductCategory>> GetProductCategory()
        {
            List<AProductCategory> data = new List<AProductCategory>();
            data = await LocalStorage.GetItemAsync<List<AProductCategory>>("ProductCategory");
            return data;
        }

        public async Task<List<AProduct>?> GetProduct()
        {
            List<AProduct>? data = new List<AProduct>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetProduct");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AProduct>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<AContacts>?> GetContacts()
        {
            List<AContacts>? data = new List<AContacts>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetContact");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AContacts>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<AFacilities>?> GetFacilities()
        {
            List<AFacilities>? data = new List<AFacilities>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetFacility");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AFacilities>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<AContactCategory>?> GetContactCategory()
        {
            List<AContactCategory>? data = new List<AContactCategory>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetContactCategory");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AContactCategory>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<FacilityPrimaryDTO?> GetFacilityPrimaryData()
        {
            FacilityPrimaryDTO? data = new FacilityPrimaryDTO();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetFacilityPrimary");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<FacilityPrimaryDTO>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<ProductPrimaryDataDTO?> GetProductPrimaryData()
        {
            ProductPrimaryDataDTO? data = new ProductPrimaryDataDTO();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetProductPrimary");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<ProductPrimaryDataDTO>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<ADrugRegimenCategory>?> GetADrugRegimenCategory()
        {
            List<ADrugRegimenCategory>? data = new List<ADrugRegimenCategory>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetADrugRegimenCategory");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADrugRegimenCategory>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ADrugRegimenClassification>?> GetADrugRegimenClassification()
        {
            List<ADrugRegimenClassification>? data = new List<ADrugRegimenClassification>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetADrugRegimenClassification");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADrugRegimenClassification>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<APhysicalCountStatus>?> GetAPhysicalCountStatus()
        {
            List<APhysicalCountStatus>? data = new List<APhysicalCountStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAPhysicalCountStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<APhysicalCountStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ARegion>?> GetARegion()
        {
            List<ARegion>? data = new List<ARegion>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetARegion");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ARegion>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ATreatmentCategory>?> GetATreatmentCategory()
        {
            List<ATreatmentCategory>? data = new List<ATreatmentCategory>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetATreatmentCategory");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ATreatmentCategory>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ADrugBasicUnit>>? GetBasicUnit()
        {
            List<ADrugBasicUnit>? data = new List<ADrugBasicUnit>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAProductBasicUnit");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADrugBasicUnit>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ACdcregion>?> GetCdcRegion()
        {
            List<ACdcregion>? data = new List<ACdcregion>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACdcregion");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACdcregion>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<ADeliveryZone>?> GetDeliveryZone()
        {
            List<ADeliveryZone>? data = new List<ADeliveryZone>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetADeliveryZone");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADeliveryZone>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ADistrict>?> GetDistrict()
        {
            List<ADistrict>? data = new List<ADistrict>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetADistrict");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADistrict>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<AImplimentingPartners>?> GetImplementingPartner()
        {
            List<AImplimentingPartners>? data = new List<AImplimentingPartners>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAImplimentingPartners");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AImplimentingPartners>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<AFacilityLevelOfCare>?> GetLevelOfCare()
        {
            List<AFacilityLevelOfCare>? data = new List<AFacilityLevelOfCare>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAFacilityLevelOfCare");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AFacilityLevelOfCare>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ASupplier>>? GetProductSupplier()
        {
            List<ASupplier>? data = new List<ASupplier>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAProductSupplier");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ASupplier>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<AProductClassification>>? GetProductClassification()
        {
            List<AProductClassification>? data = new List<AProductClassification>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAProductClassification");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AProductClassification>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<AOwnership>?> GetOwnership()
        {
            List<AOwnership>? data = new List<AOwnership>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAOwnership");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AOwnership>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveFacility(AFacilities data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveFacility", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveContact(AContacts data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveContact", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveProduct(AProduct data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveProduct", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task<List<AGender>?> GetGender()
        {
            List<AGender>? data = new List<AGender>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetGender");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AGender>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ASapBatchInformation>?> GetProductQuantities()
        {
            List<ASapBatchInformation> data = new List<ASapBatchInformation>();
            data = await LocalStorage.GetItemAsync<List<ASapBatchInformation>>("ProductQuantities");
            return data;
        }

        public async Task<List<ALabCategory1>?> GetLabCategory1()
        {
            List<ALabCategory1>? data = new List<ALabCategory1>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetLabCategory1");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ALabCategory1>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<ALabCategory2>?> GetLabCategory2()
        {
            List<ALabCategory2>? data = new List<ALabCategory2>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetLabCategory2");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ALabCategory2>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<ALabCategory3>?> GetLabCategory3()
        {
            List<ALabCategory3>? data = new List<ALabCategory3>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetLabCategory3");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ALabCategory3>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveLabCategory1(ALabCategory1 data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveLabCategory1", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        public async Task SaveLabCategory2(ALabCategory2 data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveLabCategory2", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        public async Task SaveLabCategory3(ALabCategory3 data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveLabCategory3", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAContactCategory(AContactCategory data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAContactCategory", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveADistrict(ADistrict data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveADistrict", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveADrugRegimen(ADrugRegimen data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveADrugRegimen", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveADrugRegimenCategory(ADrugRegimenCategory data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveADrugRegimenCategory", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveADrugRegimenClassification(ADrugRegimenClassification data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveADrugRegimenClassification", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAFacilityLevelOfCare(AFacilityLevelOfCare data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAFacilityLevelOfCare", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAFacilityType(AFacilityType data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAFacilityType", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAGender(AGender data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAGender", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAImplimentingPartners(AImplimentingPartners data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAImplimentingPartners", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAOrderStatus(AOrderStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAOrderStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAOrderType(AOrderType data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAOrderStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAOwnership(AOwnership data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAOwnership", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAPhysicalCountStatus(APhysicalCountStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAPhysicalCountStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAProductBasicUnit(ADrugBasicUnit data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAProductBasicUnit", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAProductCategory(AProductCategory data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAProductCategory", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAProductClassification(AProductClassification data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAProductClassification", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAProductQuantities(ASapBatchInformation data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAProductQuantities", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveAProductSupplier(ASupplier data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAProductSupplier", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveARegion(ARegion data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveARegion", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
      

        public async Task SaveATreatmentCategory(ATreatmentCategory data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveATreatmentCategory", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveCdcregion(ACdcregion data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACdcregion", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }


        public async Task SaveDeliveryZone(ADeliveryZone data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveADeliveryZone", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        //public async Task GetLogos()
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"Utilities/GetLogos");
        //        var content = await response.Content.ReadAsStringAsync();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = JsonSerializer.Deserialize<List<ImageDTO>>(content, _options);
        //            if (data != null)
        //            {
        //                await LocalStorage.SetItemAsync("Logos", data);
        //            }
        //        }
        //        else
        //        {
        //            toastService.ShowError(response.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        toastService.ShowError(ex.Message);
        //    }
        //}

        //public async Task<List<ImageDTO>> GetLocalLogos()
        //{
        //    List<ImageDTO> data = new List<ImageDTO>();
        //    try
        //    {
        //        data = await LocalStorage.GetItemAsync<List<ImageDTO>>("Logos");
        //    }
        //    catch (Exception ex)
        //    {
        //        toastService.ShowError(ex.Message);
        //    }
        //    return data;
        //}

        public async Task GetCycle()
        {
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetCycle");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<List<ACycle>>(content, _options);
                    if (data != null)
                    {
                        await LocalStorage.SetItemAsync("Cycle", data);
                    }
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task GetMonth()
        {
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetMonth");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<List<AMonth>>(content, _options);
                    if (data != null)
                    {
                        await LocalStorage.SetItemAsync("Month", data);
                    }
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task SaveCycle(ACycle data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveCycle", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    await GetCycle();
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task<List<ACycle>> GetLocalCycle()
        {
            List<ACycle> data = new List<ACycle>();
            try
            {
                data = await LocalStorage.GetItemAsync<List<ACycle>>("Cycle");
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<AMonth>> GetLocalMonth()
        {
            List<AMonth> data = new List<AMonth>();
            try
            {
                data = await LocalStorage.GetItemAsync<List<AMonth>>("Month");
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

       
        public async Task<List<ATrimester>?> GetTrimester()
        {
            List<ATrimester>? data = new List<ATrimester>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetTrimester");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ATrimester>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<SadrrOutcome>?> GetOutcome()
        {
            List<SadrrOutcome>? data = new List<SadrrOutcome>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetSADRROutcome");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<SadrrOutcome>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<SadrrOutcome>?> GetAEFIOutcome()
        {
            List<SadrrOutcome>? data = new List<SadrrOutcome>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAEFIOutcome");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<SadrrOutcome>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task<List<SadrrReaction>?> GetReactionSeriousness()
        {
            List<SadrrReaction>? data = new List<SadrrReaction>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetReactionSeriousness");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<SadrrReaction>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<AMotherStatus>?> GetMotherStatus()
        {
            List<AMotherStatus>? data = new List<AMotherStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetMotherStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AMotherStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        //agegroup method
        #region
        public async Task<List<AAgeGroups>?> GetAgeGroup()
        {
            List<AAgeGroups>? data = new List<AAgeGroups>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAgeGroup");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AAgeGroups>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task SaveAAgeGroups(AAgeGroups data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAAgeGroups", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        public async Task<List<ADose>?> GetDose()
        {
            List<ADose>? data = new List<ADose>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetDose");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADose>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        //adverse method
        #region
        public async Task<List<AAdverseEvent>?> GetAdverseEvent()
        {
            List<AAdverseEvent>? data = new List<AAdverseEvent>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAdverseEvent");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AAdverseEvent>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task SaveAAdverseEvent(AAdverseEvent data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAAdverseEvent", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //Auditsection
        #region
        public async Task<List<AAuditSection>?> GetAuditSection()
        {
            List<AAuditSection>? data = new List<AAuditSection>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAuditSection");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AAuditSection>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task SaveAuditSection(AAuditSection data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAuditSection", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //AuthorisedRep
        #region
        public async Task<List<AAuthorizedRepresentative>?> GetAuthorizedRep()
        {
            List<AAuthorizedRepresentative>? data = new List<AAuthorizedRepresentative>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAuthorizedRep");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AAuthorizedRepresentative>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }
        public async Task SaveAuthorizedRep(AAuthorizedRepresentative data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAuthorizedRep", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        public async Task<List<APvsatus>?> GetPVStatus()
        {
            List<APvsatus>? data = new List<APvsatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetPVStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<APvsatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<APvreportingType>?> GetReportingType()
        {
            List<APvreportingType>? data = new List<APvreportingType>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetReportingType");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<APvreportingType>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task<List<ACapaCompletionStatus>?> GetACapaCompletionStatus()
        {
            List<ACapaCompletionStatus>? data = new List<ACapaCompletionStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACapaCompletionStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACapaCompletionStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACapaCompletionStatus(ACapaCompletionStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACapaCompletionStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        public async Task<List<ACapaRegisterStatus>?> GetACapaRegisterStatus()
        {
            List<ACapaRegisterStatus>? data = new List<ACapaRegisterStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACapaCompletionStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACapaRegisterStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACapaRegisterStatus(ACapaRegisterStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACapaRegisterStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #region
        //public async Task<List<AVillage>?> GetVillage()
        //{
        //    List<AVillage>? data = new List<AVillage>();
        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"Utilities/GetVillage");
        //        var content = await response.Content.ReadAsStringAsync();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            data = JsonSerializer.Deserialize<List<AVillage>>(content, _options);
        //        }
        //        else
        //        {
        //            toastService.ShowError(response.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        toastService.ShowError(ex.Message);
        //    }
        //    return data;
        //}

        //public async Task SaveVillage(AVillage data)
        //{
        //    try
        //    {
        //        string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //        var result = await _httpClient.PostAsync($"Utilities/ SaveVillage", httpContent);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            toastService.ShowSuccess("Records are successfully saved....");
        //        }
        //        else
        //        {
        //            toastService.ShowError(result.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        toastService.ShowError(ex.Message);
        //    }
        //}

        #endregion
        //verification
        #region

        public async Task<List<AVerificationMethod>?> GetVerificationMethod()
        {
            List<AVerificationMethod>? data = new List<AVerificationMethod>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetVerificationMethod");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AVerificationMethod>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveVerificationMethod(AVerificationMethod data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveVerificationMethod", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //varification
        #region

        public async Task<List<AVariationStatus>?> GetVariation()
        {
            List<AVariationStatus>? data = new List<AVariationStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetVariationStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AVariationStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveVariation(AVariationStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveVariationStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //Auditsection
        #region
       
        public async Task SaveTrimester(ATrimester data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveTrimester", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
       

        //Supplier
        #region

        public async Task<List<ASupplier>?> GetASupplier()
        {
            List<ASupplier>? data = new List<ASupplier>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetASupplier");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ASupplier>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveASupplier(ASupplier data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveASupplier", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //county
        #region

        public async Task<List<ACounty>?> GetACounty()
        {
            List<ACounty>? data = new List<ACounty>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACounty");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACounty>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACounty(ACounty data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACounty", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //Subcounty
        #region

        public async Task<List<ASubcounty>?> GetASubcounty()
        {
            List<ASubcounty>? data = new List<ASubcounty>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetASubcounty");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ASubcounty>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveASubcounty(ASubcounty data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveASubcounty", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //Sectorchange
        #region

        public async Task<List<ASectorChange>?> GetASectorChange()
        {
            List<ASectorChange>? data = new List<ASectorChange>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetASectorChange");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ASectorChange>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveASectorChange(ASectorChange data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveASectorChange", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //ASAPBATCH
        #region

        public async Task<List<ASapBatchInformation>?> GetASapBatchInformation()
        {
            List<ASapBatchInformation>? data = new List<ASapBatchInformation>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetASapBatchInformation");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ASapBatchInformation>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveASapBatchInformation(ASapBatchInformation data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveASapBatchInformation", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
    //release instruction
        #region

        public async Task<List<AReleaseInstruction>?> GetReleaseInstruction()
        {
            List<AReleaseInstruction>? data = new List<AReleaseInstruction>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetReleaseInstruction");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AReleaseInstruction>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveReleaseInstruction(AReleaseInstruction data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveReleaseInstruction", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //registration status
        #region

        public async Task<List<ARegistrationStatus>?> GetARegistrationStatus()
        {
            List<ARegistrationStatus>? data = new List<ARegistrationStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetARegistrationStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ARegistrationStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveARegistrationStatus(ARegistrationStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveARegistrationStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //apvsatus
        public async Task SavePVStatus(APvsatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SavePVStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        //apvreportingtype
        #region

        public async Task<List<APvreportingType>?> GetAPVReporting()
        {
            List<APvreportingType>? data = new List<APvreportingType>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAPVReporting");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<APvreportingType>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAPVReporting(APvreportingType data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAPVReporting", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //aclienttype
        #region

        public async Task<List<AClientType>?> GetAClientType()
        {
            List<AClientType>? data = new List<AClientType>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAClientType");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AClientType>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAClientType(AClientType data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAClientType", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //acommunicationmode
        #region

        public async Task<List<ACommunicationMode>?> GetACommunicationMode()
        {
            List<ACommunicationMode>? data = new List<ACommunicationMode>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACommunicationMode");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACommunicationMode>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACommunicationMode(ACommunicationMode data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACommunicationMode", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //acommunicationmode
        #region

        public async Task<List<AComplaintActionTaken>?> GetAComplaintActionTaken()
        {
            List<AComplaintActionTaken>? data = new List<AComplaintActionTaken>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAComplaintActionTaken");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AComplaintActionTaken>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAComplaintActionTaken(AComplaintActionTaken data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAComplaintActionTaken", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //complaincategory
        #region

        public async Task<List<AComplaintCategory>?> GetAComplaintCategory()
        {
            List<AComplaintCategory>? data = new List<AComplaintCategory>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAComplaintCategory");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AComplaintCategory>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAComplaintCategory(AComplaintCategory data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAComplaintCategory", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //complaintclassification
        #region

        public async Task<List<AComplaintClassification>?> GetAComplaintClassification()
        {
            List<AComplaintClassification>? data = new List<AComplaintClassification>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAComplaintClassification");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AComplaintClassification>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAComplaintClassification(AComplaintClassification data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAComplaintClassification", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //complaintconfirmationstatus
        #region

        public async Task<List<AComplaintConfirmationStatus>?> GetAComplaintConfirmationStatus()
        {
            List<AComplaintConfirmationStatus>? data = new List<AComplaintConfirmationStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAComplaintConfirmationStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AComplaintConfirmationStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAComplaintConfirmationStatus(AComplaintConfirmationStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAComplaintConfirmationStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //complaintreportinggroup
        #region

        public async Task<List<AComplaintReportingGroup>?> GetAComplaintReportingGroup()
        {
            List<AComplaintReportingGroup>? data = new List<AComplaintReportingGroup>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAComplaintReportingGroup");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AComplaintReportingGroup>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAComplaintReportingGroup(AComplaintReportingGroup data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAComplaintReportingGroup", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //complaintstatus
        #region

        public async Task<List<AComplaintStatus>?> GetAComplaintStatus()
        {
            List<AComplaintStatus>? data = new List<AComplaintStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAComplaintStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AComplaintStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAComplaintStatus(AComplaintStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAComplaintStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //completiontimescale
        #region

        public async Task<List<ACompletionTimeScale>?> GetACompletionTimeScale()
        {
            List<ACompletionTimeScale>? data = new List<ACompletionTimeScale>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACompletionTimeScale");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACompletionTimeScale>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACompletionTimeScale(ACompletionTimeScale data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACompletionTimeScale", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //Acontacttitle
        #region

        public async Task<List<AContactTitle>?> GetAContactTitle()
        {
            List<AContactTitle>? data = new List<AContactTitle>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAContactTitle");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AContactTitle>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAContactTitle(AContactTitle data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAContactTitle", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //Acountry
        #region

        public async Task<List<ACountry>?> GetACountry()
        {
            List<ACountry>? data = new List<ACountry>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACountry");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACountry>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACountry(ACountry data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACountry", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion


        //Adeliveryzone
        #region

        public async Task<List<ADeliveryZone>?> GetADeliveryZone()
        {
            List<ADeliveryZone>? data = new List<ADeliveryZone>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetADeliveryZone");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ADeliveryZone>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveADeliveryZone(ADeliveryZone data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveADeliveryZone", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //ADOSE
        public async Task SaveDose(ADose data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveDose", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        //Ainspection
        #region

        public async Task<List<AInspectionStatus>?> GetAInspectionStatus()
        {
            List<AInspectionStatus>? data = new List<AInspectionStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAInspectionStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AInspectionStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAInspectionStatus(AInspectionStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAInspectionStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //ALaboratory
        #region

        public async Task<List<ALaboratory>?> GetLab()
        {
            List<ALaboratory>? data = new List<ALaboratory>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetLab");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ALaboratory>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveLab(ALaboratory data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveLab", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //ALtr
        #region

        public async Task<List<ALtr>?> GetLtr()
        {
            List<ALtr>? data = new List<ALtr>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetLtr");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ALtr>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveLtr(ALtr data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveLtr", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion
        //ALtr
        #region

        public async Task<List<AMonth>?> GetAMonth()
        {
            List<AMonth>? data = new List<AMonth>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAMonth");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AMonth>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAMonth(AMonth data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAMonth", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //motherstaus
        public async Task SaveAMotherStatus(AMotherStatus data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAMotherStatus", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }

        //Aorderstatus
        #region

        public async Task<List<AOrderStatus>?> GetAOrderStatus()
        {
            List<AOrderStatus>? data = new List<AOrderStatus>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAOrderStatus");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AOrderStatus>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        //public async Task SaveAOrderStatus(AOrderStatus data)
        //{
        //    try
        //    {
        //        string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //        var result = await _httpClient.PostAsync($"Utilities/SaveOrderStatus", httpContent);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            toastService.ShowSuccess("Records are successfully saved....");
        //        }
        //        else
        //        {
        //            toastService.ShowError(result.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        toastService.ShowError(ex.Message);
        //    }
        //}
        #endregion

        //AOwnership
        #region

        public async Task<List<AOwnership>?> GetAOwnership()
        {
            List<AOwnership>? data = new List<AOwnership>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAOwnership");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AOwnership>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }


        #endregion

        //ALaboratory
        #region

        public async Task<List<ACycle>?> GetACycle()
        {
            List<ACycle>? data = new List<ACycle>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetACycle");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<ACycle>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveACycle(ACycle data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveACycle", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion


        //avillage
        #region

        public async Task<List<AVillage>?> GetAVillage()
        {
            List<AVillage>? data = new List<AVillage>();
            try
            {
                var response = await _httpClient.GetAsync($"Utilities/GetAVillage");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonSerializer.Deserialize<List<AVillage>>(content, _options);
                }
                else
                {
                    toastService.ShowError(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
            return data;
        }

        public async Task SaveAVillage(AVillage data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveAVillage", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        #endregion

        //YESNO
        #region
        public async Task SaveYesNo(AYesNo data)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync($"Utilities/SaveYesNo", httpContent);
                if (result.IsSuccessStatusCode)
                {
                    toastService.ShowSuccess("Records are successfully saved....");
                }
                else
                {
                    toastService.ShowError(result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                toastService.ShowError(ex.Message);
            }
        }
        public async Task<List<AYesNo>?> GetYesNo()
        {
            List<AYesNo> data = new List<AYesNo>();
            data = await LocalStorage.GetItemAsync<List<AYesNo>>("YesNo");
            return data;
        }



        #endregion

    }
}
