using FluentValidation;

namespace BookBeacon.BL.Helpers.Validators;
// Extension method for adding custom validation rules
public static class SharedValidationRules
{
    public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 15).WithMessage("Name must be more than 2 and less than 15 characters.");
    }
    
    public static IRuleBuilderOptions<T, int> IdValidation<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Id is required.");
    }
}
