﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Covid19Radar.Services.Logs;
using Covid19Radar.Resources;
using Covid19Radar.Repository;
using Prism.Navigation;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Radar.ViewModels
{
    public class LowRiskContactPageViewModel: ViewModelBase
    {
        private readonly ILoggerService loggerService;
        private readonly IUserDataRepository userDataRepository;

        public LowRiskContactPageViewModel(
            INavigationService navigationService,
            ILoggerService loggerService,
            IUserDataRepository userDataRepository) : base(navigationService)
        {
            Title = AppResources.TitileUserStatusSettings;
            this.loggerService = loggerService;
            this.userDataRepository = userDataRepository;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            loggerService.StartMethod();
            loggerService.EndMethod();

            var totalNumberOfExposureMinutes = await calcTotalNumberOfExposureMinutes();
            TotalContactMinutes = totalNumberOfExposureMinutes.ToString();
        }

        private async Task<int> calcTotalNumberOfExposureMinutes()
        {
            var windows = await userDataRepository.GetExposureWindowsAsync();
            var numberOfExposureSecondsList = windows
                .ToArray()
                .Select(aggregateSecondsSinceLastScans);

            var totalNumberOfExposureSeconds = numberOfExposureSecondsList.Aggregate(0, (sum, x) => sum + x);

            return totalNumberOfExposureSeconds / 60;
        }

        private int aggregateSecondsSinceLastScans(Chino.ExposureWindow window) =>
            window.ScanInstances.Select(x => x.SecondsSinceLastScan).Aggregate(0, (sum, x) => sum + x);

        private string _totalContactMinutes;
        public string TotalContactMinutes
        {
            get => _totalContactMinutes;
            set => SetProperty(ref _totalContactMinutes, value);
        }
    }
}
