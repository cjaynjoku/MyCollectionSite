namespace MyCollectionSite.Models;

public class CollectionItemRepository
{
    private readonly CollectionContext _Context;

    public CollectionItemRepository(CollectionContext collectionCtx)
    {
        _Context = collectionCtx;
    }

 public IEnumerable<CollectionItem> Get()
 {
     return _Context.CollectionItems.ToArray();   
 }   

 public CollectionItem FindById(int id)
 {
    var result = _Context.CollectionItems.Find(id);
    
    if(result is null) return CollectionItem.NotFound;
    
    return result;

 }
}
