using Resume.Entities.Abstractions;

namespace Resume.Services.Abstractions;

public interface IEntityService
{
    IProfile GetProfile();
}
