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
        MatNativeDateModule
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
        MatNativeDateModule
    ]
})

export class MaterialModule {

}