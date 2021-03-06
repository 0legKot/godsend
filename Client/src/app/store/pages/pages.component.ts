﻿import { Component, Output, EventEmitter, Input } from '@angular/core';

@Component({
    selector: 'godsend-pages',
    templateUrl: './pages.component.html',
    styleUrls: ['./pages.component.css']
})
export class PagesComponent {
    page = 1;

    @Input()
    pagesCount = 1;

    @Output()
    readonly pageChanged = new EventEmitter<number>();

    constructor() { }

    nextPage() {
        if (this.page < this.pagesCount) {
            this.page++;
            this.pageChanged.emit(this.page);
        }
    }

    prevPage() {
        if (this.page > 1) {
            this.page--;
            this.pageChanged.emit(this.page);
        }
    }
}
