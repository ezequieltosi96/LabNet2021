import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/caregory/category.service';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.css']
})
export class CategoriesFormComponent implements OnInit {

  public form!: FormGroup;
  public id!: Number;
  public action: string = "Edit";

  public category!: Category;

  constructor(private readonly route: ActivatedRoute, private readonly categoryService: CategoryService, private readonly fb: FormBuilder, private readonly router: Router) { 
    
  }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id')!);

    this.categoryService.getOne(this.id).subscribe(
      cat => {
        this.category = cat;
        this.defineFormGroup();
      },
      err => {
        console.log(err);
      }
    );

    this.defineFormGroup();
  }

  defineFormGroup(){
    if (!this.category) {
      this.category = {
        Id: 0,
        Name: '',
        Description: ''
      };
      this.action = "Add New";
    }
    else{
      this.action = "Edit";
    }

    this.form = this.fb.group({
      Id: new FormControl(this.category.Id),
      Name: new FormControl(this.category.Name, [
        Validators.required,
        Validators.maxLength(15)
      ]),
      Description: new FormControl(this.category.Description)
    });
  }

  onSubmit(): void {
    this.category = this.form.value;

    if (this.category.Id === 0) {
      this.addCategory(this.category);
    }
    else {
      this.editCategory(this.category);
    }
  }

  addCategory(category: Category){
    this.categoryService.add(category).subscribe(
      res => this.router.navigate(['/categories']),
      err => console.log(err)
    );
  }

  editCategory(category: Category){
    this.categoryService.edit(category).subscribe(
      res => this.router.navigate(['/categories']),
      err => console.log(err)
    );
  }

  get name() { return this.form.get('Name'); }
}
