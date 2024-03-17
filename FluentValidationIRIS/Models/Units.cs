using FluentValidation;

namespace FluentValidationIRIS.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string? Vin { get; set; }
        public string? Make { get; set; }
        public DateTime? Year { get; set; }
        public string? Model { get; set; }
        public string? DriverName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public bool HasCollision { get; set; }
        public int CashValue { get; set; }
    }

    public class UnitValidatorPageOne : AbstractValidator<Unit>
    {      
        public UnitValidatorPageOne()   
        {
            RuleFor(unit => unit.UnitId).NotEmpty().WithMessage("UnitId is required");
            RuleFor(unit => unit.Vin).NotEmpty().WithMessage("Vin is required");
            RuleFor(unit => unit.Make).NotEmpty().WithMessage("Make is required");
            //RuleFor(unit => unit.Year).NotEmpty().WithMessage("Year is required");
            RuleFor(unit => unit.Model).NotEmpty().WithMessage("Model is required");
            RuleFor(unit => unit.HasCollision).NotNull().WithMessage("HasCollision is required");
            RuleFor(unit => unit.CashValue).NotEmpty().WithMessage("CashValue is required");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateUnit => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Unit>.CreateWithOptions((Unit)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
        //public async Task<IEnumerable<string>> ValidateUnit(Unit model, string propertyName)
        //{
        //    var result = await ValidateAsync(ValidationContext<Unit>.CreateWithOptions(model, x => x.IncludeProperties(propertyName)));
        //    if (result.IsValid)
        //        return Enumerable.Empty<string>();
        //    return result.Errors.Select(e => e.ErrorMessage);
        //}.
    }

    public class UnitValidatorPageTwo : AbstractValidator<Unit>
    {
        public UnitValidatorPageTwo()
        {
           
            RuleFor(unit => unit.DriverName).NotEmpty().WithMessage("DriverName is required");
            RuleFor(unit => unit.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(unit => unit.City).NotEmpty().WithMessage("City is required");
            RuleFor(unit => unit.State).NotEmpty().WithMessage("State is required");
            RuleFor(unit => unit.Zip).NotEmpty().WithMessage("Zip is required");
            
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidatePerson => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Unit>.CreateWithOptions((Unit)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
