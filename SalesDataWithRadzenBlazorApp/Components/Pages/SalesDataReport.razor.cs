using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using TestSalesData.Common.Models;
using TestSalesData.Service.DataService;

namespace SalesDataWithRadzenBlazorApp.Components.Pages
{
    public partial class SalesDataReport
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected ISalesDataService SalesDataService { get; set; }

        private IQueryable<SalesData> sales = new List<SalesData>().AsQueryable();

        protected override async Task OnInitializedAsync()
        {
            var filePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"CsvData\data.csv");

            var data = await SalesDataService.GetAllSalesDataFromCsvAsync(filePath);
            sales = data.AsQueryable();
        }
    }
}