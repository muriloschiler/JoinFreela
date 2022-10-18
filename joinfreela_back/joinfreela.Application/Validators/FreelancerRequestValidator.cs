using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Validators.Base;
using joinfreela.Domain.Interfaces.Repositories;

namespace joinfreela.Application.Validators
{
    public class FreelancerRequestValidator: BaseUserRequestValidator<FreelancerRequest>
    {
        public FreelancerRequestValidator(ISkillRepository _skillRepository)
        {
            RuleForEach(fr=>fr.Skills)
                .SetValidator(new SkillRequestValidator(_skillRepository));
        }
    }
}