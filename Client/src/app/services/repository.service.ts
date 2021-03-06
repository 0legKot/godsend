import { Product, ProductInfo, Category, CatsWithSubs, FilterInfo, ProductFilterInfo, ProductInfosAndCount } from '../models/product.model';
import { Injectable} from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { DataService } from './data.service';
import { Order } from '../models/order.model';
import { Supplier, SupplierInfo } from '../models/supplier.model';
import { ArticleInfo, Article } from '../models/article.model';
import { Cart, CartView, OrderPartDiscreteSend } from '../models/cart.model';
import { IEntity, IInformation } from '../models/entity.model';
import { LinkRatingEntity } from '../models/rating.model';
import { CommentWithSubs } from '../models/comment.model';
import { Image } from '../models/image.model';
import { shareReplay } from 'rxjs/operators';

export type entityClass = 'article' | 'product' | 'supplier';
export type supportedClass = entityClass | 'order';

const productsUrl = 'api/product';
const ordersUrl = 'api/order';
const suppliersUrl = 'api/supplier';
const articlesUrl = 'api/article';


@Injectable({
    providedIn: 'root'
})
export class RepositoryService {
    product: Product | {} = {};
    products: ProductInfo[] = [];
    viewedProductsIds: string[] = [];
    viewedSuppliersIds: string[] = [];
    viewedArticlesIds: string[] = [];
    //must be useless
    productsForComparement: Product[]=[];
    orders: Order[] = [];
    order: Order | {} = {};
    suppliers: SupplierInfo[] = [];
    supplier: Supplier | {} = {};
    articles: ArticleInfo[] = [];
    article: Article | {} = {};
    productsCount = 0;
    articlesCount = 0;
    suppliersCount = 0;
    ordersCount = 0;
    productFilter: ProductFilterInfo = new ProductFilterInfo(10, 1);
    comments: any = {};

    private productsExperimentPusher = new Subject<ProductInfo[]>();
    // Re-emits last value on new subscribe
    productsExperiment = this.productsExperimentPusher.asObservable().pipe(shareReplay(1));

    constructor(private data: DataService) {
    }

    getSavedEntities(clas: supportedClass) {
        switch (clas) {
            case 'product':
                return this.products;
            case 'order':
                return this.orders;
            case 'supplier':
                return this.suppliers;
            case 'article':
                return this.articles;
        }
    }

    setEntity<T>(val: T) {
        switch (typeof(val)) {
            case typeof (Product):
                this.product = val;
                break;
            case typeof (Supplier):
                this.supplier = val;
                break;
            case typeof (Order):
                this.order = val;
                break;
            default: return;
        }
    }


    setEntities<T>(clas: supportedClass, val: T[]) {
        switch (clas) {
            case 'product':
                this.products = <any>val;
                break;
            case 'order':
                this.orders = <any>val;
                break;
            case 'supplier':
                this.suppliers = <any>val;
                break;
            case 'article':
                this.articles = <any>val;
                break;
        }
    }

    setEntitiesCount(clas: supportedClass, val: number) {
        switch (clas) {
            case 'product':
                this.productsCount = val;
                break;
            case 'order':
                this.ordersCount = val;
                break;
            case 'supplier':
                this.suppliersCount = val;
                break;
            case 'article':
                this.articlesCount = val;
                break;
        }
    }

    getUrl(clas: supportedClass): string {
        switch (clas) {
            case 'product': return productsUrl;
            case 'order': return ordersUrl;
            case 'supplier': return suppliersUrl;
            case 'article': return articlesUrl;
        }
        return 'urlNotDetected';
    }

    getEntity<T>(clas: supportedClass, id: string, fn: (_: T) => any) {
        if (id != null) {
            const url = this.getUrl(clas);
            this.data.sendRequest<T>('get', url + '/detail/' + id)
                .subscribe(response => {
                    this.setEntity<T>(response);
                    if (fn) {
                        fn(response);
                    }
                });
        }
    }
    //redo for entities
    getProductsForComparement(clas: supportedClass, ids: string[], fn: (_: Product[]) => any) {
        this.productsForComparement = Array<Product>();
            const url = this.getUrl(clas);
        ids.forEach(id => {
            if (id != null) {
                this.data.sendRequest<Product>('get', url + '/detail/' + id)
                    .subscribe(response => {

                        this.productsForComparement.push(response);

                    });
            }
        });
        if (fn) {
            fn(this.productsForComparement);
        }
    }

    getEntityComments(clas: entityClass, id: string, fn: (_: CommentWithSubs[]) => any) {
        const url = this.getUrl(clas);
        this.data.sendRequest<CommentWithSubs[]>('get', url + '/comments/' + id)
            .subscribe(response => {
                fn(response);
            });
    }

    sendComment(clas: entityClass, id: string, baseId: string | null, commentText: string, fn: (_: any) => any) {
        const url = this.getUrl(clas);
        this.data.sendRequest<any>('post', url + '/AddComment/' + id + (baseId != null ? '/' + baseId : ''), { comment: commentText })
            .subscribe(response => {
                if (fn) {
                    fn(response);
                }
            });
    }

    deleteComment(clas: entityClass, id: string, commentId: string, fn?: (_: void) => any) {
        const url = this.getUrl(clas);
        this.data.sendRequest<void>('delete', `${url}/deletecomment/${id}/${commentId}`)
            .subscribe(response => {
                if (fn) {
                    fn(response);
                }
            });
    }

    editComment(clas: entityClass, commentId: string, content: string, fn?: (_: void) => any) {
        const url = this.getUrl(clas);
        this.data.sendRequest<void>('patch', `${url}/editcomment/${commentId}`, { comment: content })
            .subscribe(response => {
                if (fn) {
                    fn(response);
                }
            });
    }

    changeOrderStatus(id: string, status: number, page: number, rpp: number, fn?: ((_: Order[]) => any)) {
        this.data.sendRequest<Order[]>('patch', ordersUrl + '/changeStatus/' + id + '/' + status)
            .subscribe(response => {
                this.getEntities<Order>('order', page, rpp, fn);
            });
    }

    deleteOrder(id: string, page: number, rpp: number, fn?: ((_: Order[]) => any)) {
        this.data.sendRequest<Order[]>('delete', ordersUrl + '/delete/' + id)
            .subscribe(response => {
                this.getEntities<Order>('order', page, rpp, fn);
            });
    }

    getEntities<T>(clas: supportedClass, page: number, rpp: number, fn?: (_: T[]) => any) {
        if (clas === 'product') {
            this.getByFilter();
        } else {
            const url = this.getUrl(clas);

            // const page = 1;
            // const rpp = 15;

            this.data.sendRequest<T[]>('get', url + '/all/' + page + '/' + rpp)
                .subscribe(response => {
                    if (fn) {
                        fn(response);
                    }

                    this.setEntities<T>(clas, response);
                });
        }

        this.getEntitiesCount(clas);
    }

    getEntitiesCount(clas: supportedClass, fn?: (_: number) => any) {
        const url = this.getUrl(clas);

        this.data.sendRequest<number>('get', url + '/count')
            .subscribe(response => {
                this.setEntitiesCount(clas, response);
                if (fn) {
                    fn(response);
                }
            });
    }

    createOrder(cartView: CartView) {

        console.dir(cartView);

        const cart = new Cart(
            cartView.discreteItems.map(opdv => new OrderPartDiscreteSend(opdv.quantity, opdv.productInfo.id, opdv.supplierInfo.id))
        );

        this.data.sendRequest<Order>('post', ordersUrl + '/createOrUpdate', cart)
            .subscribe(response => {
                this.orders.push(response);
            });
    }

    createOrEditEntity<T extends IEntity<IInformation>>(clas: supportedClass, entity: T, page: number, rpp: number,
                                                        fn?: (_: IInformation) => any) {
        const createEditData = entity.toCreateEdit();
        const url = this.getUrl(clas);
        console.log(createEditData);
        this.data.sendRequest<string>('post', url + '/CreateOrUpdate', createEditData)
            .subscribe(response => {
                entity.info.id = response;
                this.getEntities(clas, page, rpp);
                if (fn) {
                    fn(entity.info);
                }
            });

    }

    // deprecated?
    replaceProduct(prod: Product, page: number, rpp: number) {
        const data = {
            name: prod.info.name,
            description: prod.info.description
        };
        this.data.sendRequest<null>('put', productsUrl + '/' + prod.id, data)
            .subscribe(response => this.getEntities<Product>('product', page, rpp));
    }

    updateEntity<T>(clas: supportedClass, id: string, changes: Map<string, any>, page: number, rpp: number) {
        const url = this.getUrl(clas);
        const patch: any[] = [];
        changes.forEach((value, key) =>
            patch.push({ op: 'replace', path: key, value: value }));

        this.data.sendRequest<null>('patch', url + '/' + id, patch)
            .subscribe(response => this.getEntities<T>(clas, page, rpp));
    }

    deleteEntity(clas: supportedClass, id: string, page: number, rpp: number, fn?: () => any) {
        const url = this.getUrl(clas);
        this.data.sendRequest<null>('delete', url + '/delete/' + id)
            .subscribe(_ => {
                this.getEntities<null>(clas, page, rpp);
                if (fn) {
                    fn();
                }
            });
    }


    storeSessionData(dataType: string, data: any) {
        return this.data.sendRequest<null>('post', '/api/session/' + dataType, data)
            .subscribe(response => { });
    }

    getSessionData(dataType: string): Observable<any> {
        return this.data.sendRequest<any>('get', '/api/session/' + dataType);
    }

    getByFilter(fn?: (_: ProductInfo[]) => any): void {
        this.data.sendRequest<ProductInfosAndCount>('post', 'api/product/byFilter', this.productFilter)
            .subscribe(result => {
                this.products = result.infos;
                this.productsExperimentPusher.next(result.infos);
                this.productsCount = result.count;
                if (fn) {
                    fn(result.infos);
                }
            });
    }

    saveRating(clas: entityClass, id: string, rating: number, fn?: (_: number) => any) {
        const url = this.getUrl(clas);

        this.data.sendRequest<number>('post', `${url}/setRating/${id}/${rating}`)
            .subscribe(result => {
                if (fn) {
                    fn(result);
                }
            });
    }

    getAllRatings(clas: entityClass, entityId: string, fn?: (_: LinkRatingEntity[]) => any) {
        const url = this.getUrl(clas);

        this.data.sendRequest<LinkRatingEntity[]>('get', `${url}/ratings/${entityId}`)
            .subscribe(result => {
                if (fn) {
                    fn(result);
                }
            });
    }

    getUserRating(clas: entityClass, entityId: string, fn?: (_: number) => any) {
        const url = this.getUrl(clas);

        this.data.sendRequest<number>('get', `${url}/rating/${entityId}`)
            .subscribe(result => {
                if (fn) {
                    fn(result);
                }
            });
    }

    uploadImages(data: FormData, fn?: (_: Image[]) => any) {
        this.data.sendRequest<Image[]>('post', `api/image/upload`, data)
            .subscribe(response => {
                if (fn) {
                    fn(response);
                }
            })
    }
}
