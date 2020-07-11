import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        ReactiveFormsModule,
        FormsModule,
        CommonModule,
        MaterialModule,
        FlexLayoutModule
    ],
    exports: [
        ReactiveFormsModule,
        FormsModule,
        CommonModule,
        MaterialModule,
        FlexLayoutModule
    ]
})
export class SharedModule { }