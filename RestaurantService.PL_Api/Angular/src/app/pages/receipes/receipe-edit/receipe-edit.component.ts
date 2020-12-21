import {Component, OnInit} from '@angular/core';
import {ApiReceipeService} from '../../../core/_services/api.receipe.service';
import {ActivatedRoute, Router} from '@angular/router';
import {FormArray, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ApiIngredientService} from '../../../core/_services/api.ingredient.service';

@Component({
  selector: 'app-receipe-edit',
  templateUrl: './receipe-edit.component.html',
  styleUrls: ['./receipe-edit.component.scss'],
  providers: [ApiReceipeService, ApiIngredientService]
})
export class ReceipeEditComponent implements OnInit {
  id: string;
  form: FormGroup;
  submitted = false;
  ingredients: any;

  constructor(
    private apiReceipeService: ApiReceipeService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private apiIngredientService: ApiIngredientService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.apiIngredientService.getItems()
      .subscribe((data) => {
        this.ingredients = data;
      });
    this.id = this.route.snapshot?.paramMap?.get('id')?.toString() || '';
    if (this.id !== '0') {
      this.apiReceipeService.getItemsParams(this.route.snapshot?.paramMap?.get('id')?.toString() || '')
        .subscribe((data) => {
          this.initForm(data);
        });
    } else {
      this.initForm(null);
    }
  }

  initForm(data) {
    this.form = this.fb.group({
      name: [data?.name || '', [Validators.required, Validators.pattern('^[a-zA-Z _]+$')]],
      category: [data?.category || '', [Validators.required, Validators.pattern('^[a-zA-Z _]+$')]],
      minutes: [data?.time?.minutes || 0, Validators.required],
      seconds: [data?.time?.seconds || 0, Validators.required],
      ingredients: this.fb.array([]),
      id: [data?.id || null],
      pricePerGram: [data?.pricePerGram || 0]
    });
    if (data?.ingredients?.length) {
      data.ingredients.forEach((item, index) => {
        (this.form?.get('ingredients') as FormArray).push(this.fb.group({
          name: [item, Validators.required]
        }));
      });
    }
    this.form.get('name').valueChanges.subscribe((val) => {
      if (val.length === 1 && val === ' ') {
        this.form.get('name').setValue('', {emitEvent: false})
      }
    });
    this.form.get('category').valueChanges.subscribe((val) => {
      if (val.length === 1 && val === ' ') {
        this.form.get('category').setValue('', {emitEvent: false})
      }
    })
  }


  addIngredients() {
    this.submitted = true;
    if (this.form?.valid) {
      (this.form?.get('ingredients') as FormArray).push(this.fb.group({
        name: ['', Validators.required]
      }));
    }
  }

  deleteArrayIng(index) {
    (this.form?.get('ingredients') as FormArray).removeAt(index);
  }

  addIngredient() {
    this.submitted = true;
    if (this.form?.valid) {
      (this.form?.get('ingredients') as FormArray).push(this.fb.group({
        name: ['', Validators.required]
      }));
    }
  }

  submit() {
    this.submitted = true;
    if (this.form?.invalid) {
      return;
    }
    const ingredients = this.form?.get('ingredients').value.map(x => x.name);
    const payload = {
      ...this.form?.value,
      ingredients,
      time: {
        minutes: this.form?.value?.minutes,
        seconds: this.form?.value?.seconds
      }
    };
    if (!payload.id) {
      delete payload.id;
    }
    if (!ingredients.length) {
      delete payload.ingredients;
    }
    if (this.id !== '0') {
      this.apiReceipeService.updateItemPost(payload).subscribe(() => {
        this.router.navigate(['/recipes']);
      });
    } else {
      this.apiReceipeService.createItemPut(payload).subscribe(() => {
        this.router.navigate(['/recipes']);
      });
    }
  }

}
