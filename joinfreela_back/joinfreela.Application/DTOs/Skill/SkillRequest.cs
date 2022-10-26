using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Skill
{
    public class SkillRequest : RegisterRequest
    {
        public string Name { get; set; }
    }
}