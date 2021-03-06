﻿import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/internal/operators';

type allowedMethod = 'get' | 'post' | 'put' | 'patch' | 'delete';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    public sendRequest<T>(method: allowedMethod, url: string, data?: any)
        : Observable<T> {
        console.log(url);
        return this.http.request<T>(method, this.baseUrl + url, { body: data, responseType: 'json', headers: this.getHeaders() }).pipe(
            map(response => {
                console.log(this.baseUrl + url);
                if (data) {
                    console.log('data');
                    console.dir(data);
                }
                console.log(url);
                console.log(response);
                return response;
            }));
    }

    private getHeaders(): any {
        // set auth token
        const token = localStorage.getItem('godsend_authtoken');
        if (token) {
            const headers = new HttpHeaders({ 'Authorization': 'Bearer ' + token });
            console.log('headers');
            console.dir(headers);
            return headers;
        } else {
            return null;
        }
    }
}
