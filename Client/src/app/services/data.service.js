var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/internal/operators';
var DataService = /** @class */ (function () {
    function DataService(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    DataService.prototype.sendRequest = function (method, url, data) {
        var _this = this;
        console.log(url);
        return this.http.request(method, this.baseUrl + url, { body: data, responseType: 'json', headers: this.getHeaders() }).pipe(map(function (response) {
            console.log(_this.baseUrl + url);
            if (data) {
                console.log('data');
                console.dir(data);
            }
            console.log(url);
            console.log(response);
            return response;
        }));
    };
    DataService.prototype.getHeaders = function () {
        // set auth token
        var token = localStorage.getItem('godsend_authtoken');
        if (token) {
            var headers = new HttpHeaders({ 'Authorization': 'Bearer ' + token });
            console.log('headers');
            console.dir(headers);
            return headers;
        }
        else {
            return null;
        }
    };
    DataService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __param(1, Inject('BASE_URL')),
        __metadata("design:paramtypes", [HttpClient, String])
    ], DataService);
    return DataService;
}());
export { DataService };
//# sourceMappingURL=data.service.js.map