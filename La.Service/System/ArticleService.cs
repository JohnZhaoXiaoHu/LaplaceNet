using La.Infra.Attribute;
using La.Model.System;
using La.Service.System.IService;

namespace La.Service.System
{
    /// <summary>
    /// 
    /// </summary>
    [AppService(ServiceType = typeof(IArticleService), ServiceLifetime = LifeTime.Transient)]
    public class ArticleService : BaseService<Article>, IArticleService
    {
    }
}
