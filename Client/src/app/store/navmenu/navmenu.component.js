var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../../services/storage.service';
import { AuthenticationService } from '../../services/authentication.service';
import { TranslateService } from '@ngx-translate/core';
var NavMenuComponent = /** @class */ (function () {
    function NavMenuComponent(storage, auth, router, translateService) {
        this.storage = storage;
        this.auth = auth;
        this.router = router;
        this.translateService = translateService;
        this.showMenuMobile = false;
    }
    Object.defineProperty(NavMenuComponent.prototype, "name", {
        get: function () { return this.storage.name; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NavMenuComponent.prototype, "isLogged", {
        get: function () { return this.storage.authenticated; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NavMenuComponent.prototype, "isAdmin", {
        get: function () { return Boolean(this.auth.roles.find(function (x) { return x == 'Administrator' || x == 'Moderator'; })); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NavMenuComponent.prototype, "currentUserId", {
        get: function () { return this.storage.id; },
        enumerable: true,
        configurable: true
    });
    NavMenuComponent.prototype.scrollToTop = function () {
        window.scrollTo(0, 0);
    };
    NavMenuComponent.prototype.slideToggle = function () {
        this.showMenuMobile = !this.showMenuMobile;
    };
    NavMenuComponent.prototype.hideMenu = function () {
        this.showMenuMobile = false;
    };
    NavMenuComponent.prototype.ngOnInit = function () {
        this.selectedLang = this.translateService.currentLang;
        this.availableLangs = this.translateService.getLangs();
    };
    NavMenuComponent.prototype.changeLang = function (newLang) {
        console.log('Changing lang to ' + newLang);
        this.translateService.use(newLang);
    };
    NavMenuComponent.prototype.logout = function () {
        this.auth.logout();
    };
    NavMenuComponent.prototype.login = function () {
        this.auth.callbackUrl = this.router.routerState.snapshot.url;
        this.router.navigateByUrl('/login');
    };
    NavMenuComponent = __decorate([
        Component({
            selector: 'godsend-nav-menu',
            templateUrl: './navmenu.component.html',
            styleUrls: ['./navmenu.component.css']
        }),
        __metadata("design:paramtypes", [StorageService,
            AuthenticationService,
            Router,
            TranslateService])
    ], NavMenuComponent);
    return NavMenuComponent;
}());
export { NavMenuComponent };
//# sourceMappingURL=navmenu.component.js.map