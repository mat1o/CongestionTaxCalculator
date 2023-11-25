using CongestionTaxCalculator.Service.ViewModels;

namespace CongestionTaxCalculator.Service.Utilities
{
    public static class Mapper 
    {
        public static TModel MapToMainModel<TModel, TViewModel>(this TViewModel viewModel)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            return mapper.Map<TModel>(viewModel);
        }

        public static TViewModel MapToViewModel<TModel, TViewModel>(this TModel model)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            return mapper.Map<TViewModel>(model);
        }
    }
    
}
