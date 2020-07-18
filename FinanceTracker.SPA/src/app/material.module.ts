import { NgModule } from '@angular/core';
import { MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatDatepickerModule,
    MatCheckboxModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    MatListModule,
    MatTabsModule,
    MatSelectModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatNativeDateModule
} from '@angular/material';

import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';

@NgModule({
    imports: [
        MatButtonModule,
        MatIconModule,
        MatDatepickerModule,
        MatInputModule,
        MatCheckboxModule,
        MatSidenavModule,
        MatListModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTabsModule,
        MatSelectModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatSnackBarModule,
        MatNativeDateModule,
        CdkTableModule,
        CdkTreeModule
    ],
    exports: [
        MatButtonModule,
        MatIconModule,
        MatDatepickerModule,
        MatInputModule,
        MatCheckboxModule,
        MatSidenavModule,
        MatListModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTabsModule,
        MatSelectModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatSnackBarModule,
        MatNativeDateModule,
        CdkTableModule,
        CdkTreeModule
    ]
})

export class MaterialModule {

}