using System;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using TestApi2.Application.Features.ExtendedAttributes.Commands.AddEdit;
using TestApi2.Client.Extensions;
using TestApi2.Client.Infrastructure.Managers.ExtendedAttribute;
using TestApi2.Domain.Contracts;
using TestApi2.Domain.Enums;
using TestApi2.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;

namespace TestApi2.Client.Shared.Components
{
    public class AddEditExtendedAttributeModalLocalization
    {
        // for localization
    }

    public partial class AddEditExtendedAttributeModal<TId, TEntityId, TEntity, TExtendedAttribute>
        where TEntity : AuditableEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
        where TExtendedAttribute : AuditableEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
        where TId : IEquatable<TId>
    {
        [Inject] private IExtendedAttributeManager<TId, TEntityId, TEntity, TExtendedAttribute> ExtendedAttributeManager { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [Parameter] public AddEditExtendedAttributeCommand<TId, TEntityId, TEntity, TExtendedAttribute> AddEditExtendedAttributeModel { get; set; } = new();

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        private MudDatePicker _datePicker;
        private MudTimePicker _timePicker;
        private TimeSpan? _time;

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            switch (AddEditExtendedAttributeModel.Type)
            {
                case EntityExtendedAttributeType.Decimal:
                    AddEditExtendedAttributeModel.DateTime = null;
                    AddEditExtendedAttributeModel.Text = null;
                    AddEditExtendedAttributeModel.Json = null;
                    break;
                case EntityExtendedAttributeType.Text:
                    AddEditExtendedAttributeModel.Decimal = null;
                    AddEditExtendedAttributeModel.DateTime = null;
                    AddEditExtendedAttributeModel.Json = null;
                    break;
                case EntityExtendedAttributeType.DateTime:
                    AddEditExtendedAttributeModel.DateTime ??= new DateTime(0, 0, 0);
                    AddEditExtendedAttributeModel.DateTime += _time ?? new TimeSpan(0, 0, 0);
                    AddEditExtendedAttributeModel.Decimal = null;
                    AddEditExtendedAttributeModel.Text = null;
                    AddEditExtendedAttributeModel.Json = null;
                    break;
                case EntityExtendedAttributeType.Json:
                    AddEditExtendedAttributeModel.Decimal = null;
                    AddEditExtendedAttributeModel.Text = null;
                    AddEditExtendedAttributeModel.DateTime = null;
                    break;
            }

            var response = await ExtendedAttributeManager.SaveAsync(AddEditExtendedAttributeModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
            await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }
    }
}