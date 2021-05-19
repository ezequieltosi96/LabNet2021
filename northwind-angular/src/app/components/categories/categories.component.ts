import { Component, OnInit } from '@angular/core';

import { CategoryService } from 'src/app/services/caregory/category.service';
import { Category } from 'src/app/models/category';
import { Observable } from 'rxjs';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  public searchForm!: FormGroup;
  public categories$!: Observable<Category[]>;

  constructor(private readonly categoryService: CategoryService, private readonly fb: FormBuilder) { }

  ngOnInit(): void {
    this.loadAllCategories();
    this.defineSearchForm();
  }

  defineSearchForm(){
    this.searchForm = this.fb.group({
      searchString: new FormControl('')
    });

    this.searchForm.controls['searchString'].valueChanges.subscribe(
      data => {
        this.loadAllCategories(data);
      }
    )
  }

  loadAllCategories(searchString: string = "") {
    this.categories$ = this.categoryService.getAll(searchString);
    
  }

  handleDelete(id: number, name: string): void {
    if(!confirm(`Are you sure you want to delete ${name}?`)) return;
    this.categoryService.delete(id).subscribe(
      res=> {
        this.loadAllCategories();
        console.log('Deleted category with id ', res)
      },
      err => console.log('An error has been thrown deleting a category. ', err)
    );
    
  }
}
