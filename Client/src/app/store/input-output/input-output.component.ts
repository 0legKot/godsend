import { Component, Input } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { CustomControlValueAccessor } from '../shared/custom-control-value-accessor';

@Component({
    selector: 'godsend-input-output',
    templateUrl: './input-output.component.html',
    styleUrls: ['./input-output.component.css'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: InputOutputComponent,
            multi: true
        }
    ]
})
export class InputOutputComponent extends CustomControlValueAccessor<string> {
    @Input()
    edit = false;
    @Input()
    class = 'default';
    @Input()
    type: InputOutputType = 'normal';

    constructor() { super(); }
}

export type InputOutputType = 'normal' | 'huge' | 'decimal' | 'integer' | 'datetime';
