using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Skill
{
    public class UserSkillRequest: RegisterRequest
    {
        public int SkillId { get; set; }
    }
}