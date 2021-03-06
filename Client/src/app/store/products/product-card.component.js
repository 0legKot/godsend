var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProductInfo } from '../../models/product.model';
import { RepositoryService } from '../../services/repository.service';
import { ImageService } from '../../services/image.service';
import { AuthenticationService } from '../../services/authentication.service';
var ProductCardComponent = /** @class */ (function () {
    function ProductCardComponent(repo, imageService, auth) {
        this.repo = repo;
        this.imageService = imageService;
        this.auth = auth;
        this.delete = new EventEmitter();
    }
    Object.defineProperty(ProductCardComponent.prototype, "canDelete", {
        get: function () {
            return Boolean(this.auth.roles.find(function (x) { return x == 'Administrator' || x == 'Moderator'; }));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ProductCardComponent.prototype, "viewed", {
        get: function () {
            var _this = this;
            return this.productInfo && (this.repo.viewedProductsIds.find(function (id) { return id === _this.productInfo.id; }) !== undefined);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ProductCardComponent.prototype, "imagePath", {
        get: function () {
            if (this.productInfo && this.productInfo.preview) {
                return this.imageService.getImagePath(this.productInfo.preview.id);
            }
            else {
                return '';
            }
        },
        enumerable: true,
        configurable: true
    });
    ProductCardComponent.prototype.onDelete = function () {
        this.delete.emit();
    };
    __decorate([
        Input(),
        __metadata("design:type", ProductInfo)
    ], ProductCardComponent.prototype, "productInfo", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ProductCardComponent.prototype, "delete", void 0);
    ProductCardComponent = __decorate([
        Component({
            selector: 'godsend-product-card[productInfo]',
            templateUrl: './product-card.component.html',
            styleUrls: ['./products.component.css']
        }),
        __metadata("design:paramtypes", [RepositoryService, ImageService, AuthenticationService])
    ], ProductCardComponent);
    return ProductCardComponent;
}());
export { ProductCardComponent };
//# sourceMappingURL=product-card.component.js.map