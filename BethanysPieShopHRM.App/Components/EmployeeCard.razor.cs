using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using static System.Net.Mime.MediaTypeNames;

namespace BethanysPieShopHRM.App.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string? _imageDataURL;

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(Employee.LastName))
            {
                throw new Exception("Last name can't be empty");
            }

            if (Employee.ImageContent != null)
            {
                var imagesrc = Convert.ToBase64String(Employee.ImageContent);
                _imageDataURL = string.Format("data:image/jpeg;base64,{0}", imagesrc);
            }

        }

        public void NavigateToDetails(Employee selectedEmployee)
        {

            NavigationManager.NavigateTo($"/employeedetail/{selectedEmployee.EmployeeId}");

        }
    }
}
