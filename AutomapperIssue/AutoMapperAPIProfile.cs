namespace AutoMapperIssue
{
    public class AutoMapperAPIProfile : AutoMapper.Profile
    {
        public override string ProfileName => GetType().ToString();

        public AutoMapperAPIProfile()
        {
            CreateMap<UserNoteDto, UserNote>();
        }
    }
}
