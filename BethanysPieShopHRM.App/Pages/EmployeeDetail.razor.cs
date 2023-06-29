using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        private string? _imageDataURL;

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            if(Employee.Longitude.HasValue && Employee.Latitude.HasValue)
            {
                MapMarkers = new List<Marker>()
                {
                    new Marker{Description=$"{Employee.FirstName} {Employee.LastName}",
                    ShowPopup = false, X = Employee.Longitude.Value, Y = Employee.Latitude.Value}
                };
            }


            if (Employee.ImageContent != null)
            {
                var imagesrc = Convert.ToBase64String(Employee.ImageContent);
                _imageDataURL = string.Format("data:image/jpeg;base64,{0}", imagesrc);
            }

        }
    }
}
