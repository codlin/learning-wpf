using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasDemo.RegionTools.ViewModels
{
    class RegionToolWindowViewModel : ObservableObject
    {
        public RegionToolWindowViewModel()
        {
            IsRegionRectBtnChecked = false;
        }

        bool _isRegionRectBtnChecked;
        public bool IsRegionRectBtnChecked
        {
            get => _isRegionRectBtnChecked;
            set => SetProperty(ref _isRegionRectBtnChecked, value);
        }

        // 清除选取的 RelayCommand
        public RelayCommand ClearRegionCommand { get; set; }
    }
}
