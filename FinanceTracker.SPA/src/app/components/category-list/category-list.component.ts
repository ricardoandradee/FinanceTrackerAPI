import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { YesNoDialogComponent } from '../../shared/yes.no.dialog.component';
import { Category } from '../../models/category.model';
import { CategoryAddComponent } from '../category-add/category-add.component';
import { UiService } from '../../services/ui.service';
import { CategoryService } from 'src/app/services/category.service';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import * as fromRoot from 'src/app/reducers/app.reducer';
import * as UI from 'src/app/actions/ui.actions';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  displayedColumns = ['CreatedDate', 'Description', 'Name', 'Actions'];
  dataSource = new MatTableDataSource<Category>();
  isLoading$: Observable<boolean>;

  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  editCategory: Category;
  oldCategory: { id: number; userId: string; name: string; description: string; createdDate?: Date; };
  rowInEditMode: boolean;
  
  constructor(private dialog: MatDialog, private uiService: UiService,
              private categoryService: CategoryService, private store: Store<{ui: fromRoot.State}>) { }

  ngOnInit() {
    this.isLoading$ = this.store.select(fromRoot.getIsLoading);
    this.categoryService.getCategoriesForUser().subscribe((categories: Category[]) => {
      this.categoryService.setCategories = categories;
    });
    
    this.categoryService.getCategories.subscribe((categories: Category[]) => {
      this.dataSource.data = categories;
    });
    
  }
  
  openDialog() {
      const dialogRef = this.dialog.open(CategoryAddComponent);
      dialogRef.afterClosed().subscribe(result => {
        if (result.data) {
          this.createCategory(result.data as Category);
        }
      });
  }

  private createCategory(category: Category) {
    this.store.dispatch(new UI.StartLoading());
    this.categoryService.createCategory(category).subscribe(response => {
      if (response.ok) {
        const categoryCreated = response.body as Category;

        const categoriesFromDataSource = this.dataSource.data;
        categoriesFromDataSource.push(categoryCreated);
        this.categoryService.setCategories = categoriesFromDataSource;

        this.uiService.showSnackBar('Category was sucessfully created.', 3000);
      } else {
        this.uiService.showSnackBar('There was an error while creating a category, please, try again later.', 3000);
      }
    }, (err) => {
        this.uiService.showSnackBar(err.error, 3000);
    }, () => { this.store.dispatch(new UI.StopLoading()); });
  }
  
  onSave(form: NgForm) {
    this.createCategory({ name: form.value.name, description: form.value.description, createdDate: new Date() } as Category);
  }
  
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  doFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onDelete(category: Category) {
    if (!category.canBeDeleted) {
      this.uiService.showSnackBar('This category has payments linked to it, therefore, it cannot be removed.', 3000);
    } else {
      const dialogRef = this.dialog.open(YesNoDialogComponent, { data: { message: "Are you sure you want to delete this category?", title: "Are you sure?" } });
      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          this.store.dispatch(new UI.StartLoading());
          this.categoryService.deleteCategory(category.id).subscribe(response => {
            var categoriesFromDataSource = this.dataSource.data;
            let categoryIndex = categoriesFromDataSource.findIndex(x => x.id === category.id);
            if (categoryIndex > -1) {
              categoriesFromDataSource.splice(categoryIndex, 1);
            }
            this.categoryService.setCategories = categoriesFromDataSource;
        }, (err) => {
            this.uiService.showSnackBar(err.error, 3000);
        }, () => { this.store.dispatch(new UI.StopLoading()); });
        }
      });
    }
  }

  onEdit(category: Category) {
    this.editCategory = category && category.id ? category : {} as Category;
    this.oldCategory = {...this.editCategory};
    this.rowInEditMode = true;
  }

  onSaveChanges() {
    this.store.dispatch(new UI.StartLoading());
    this.categoryService.updateCategory(this.editCategory).subscribe(response => {
      if (response.ok) {
        var categoriesFromDataSource = this.dataSource.data;

        let categoryIndex = categoriesFromDataSource.findIndex(x => x.id === this.editCategory.id);
        if (categoryIndex > -1) {
          categoriesFromDataSource.splice(categoryIndex, 1);
          categoriesFromDataSource.splice(categoryIndex, 0, this.editCategory);
        }

        this.categoryService.setCategories = categoriesFromDataSource;
        this.editCategory = {} as Category;
        this.onCancelEdit();
        this.uiService.showSnackBar('Category successfully updated.', 3000);
        }else{
          this.uiService.showSnackBar('There was an error while trying to update category. Please, try again later!', 3000);
        }
    }, (err) => {
        this.uiService.showSnackBar(err.error, 3000);
        this.onCancelEdit();
    }, () => { this.store.dispatch(new UI.StopLoading()); });
  }

  onCancelEdit(){
    this.rowInEditMode = false;
    this.editCategory = {} as Category;
    this.oldCategory = {} as Category;
  }
}