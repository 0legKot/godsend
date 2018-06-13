var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { ProductInfo } from '../../models/product.model';
import { RepositoryService } from '../../services/repository.service';
var ProductCardComponent = /** @class */ (function () {
    function ProductCardComponent(repo) {
        this.repo = repo;
    }
    ProductCardComponent.prototype.delete = function () {
        if (this.productInfo)
            this.repo.deleteEntity("product", this.productInfo.id);
    };
    __decorate([
        Input(),
        __metadata("design:type", ProductInfo)
    ], ProductCardComponent.prototype, "productInfo", void 0);
    ProductCardComponent = __decorate([
        Component({
            selector: 'godsend-product-card[productInfo]',
            templateUrl: './product-card.component.html',
            styleUrls: ['./products.component.css']
        }),
        __metadata("design:paramtypes", [RepositoryService])
    ], ProductCardComponent);
    return ProductCardComponent;
}());
export { ProductCardComponent };
//# sourceMappingURL=product-card.component.js.map