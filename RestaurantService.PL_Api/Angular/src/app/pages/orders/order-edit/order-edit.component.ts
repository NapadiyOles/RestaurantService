import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiOrdersService} from '../../../core/_services/api.orders.service';
import {AbstractControl, FormArray, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ApiIngredientService} from '../../../core/_services/api.ingredient.service';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.scss'],
  providers: [ApiOrdersService]
})
export class OrderEditComponent implements OnInit {
  data: any;
  form: FormGroup | undefined;
  dishNames = [];
  submitted = false;
  id: any;
  ingredients: any;

  constructor(
    private route: ActivatedRoute,
    private apiOrdersService: ApiOrdersService,
    private fb: FormBuilder,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.apiOrdersService.getItemsParams('GetDishNames')
      .subscribe((data: any) => {
        this.dishNames = data;
      });
    this.id = this.route.snapshot?.paramMap?.get('id');
    if (this.id !== '0') {
      this.apiOrdersService.getItemsParams(this.route.snapshot?.paramMap?.get('id')?.toString() || '')
        .subscribe((data: any) => {
          this.data = data;
          this.initForm(data);
        });
    } else {
      this.initForm(null);
    }
  }

  initForm(data: any) {
    this.form = this.fb.group({
      name: [data?.name || '', [Validators.pattern('^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}\'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)'), Validators.required]],
      tableNumber: [data?.tableNumber || ''],
      id: [data?.id || null],
      dishes: this.fb.array([])
    });
    if (data.dishes?.length) {
      data.dishes.forEach((item, index) => {
        (this.form?.get('dishes') as FormArray).push(this.fb.group({
          name: [item.name, Validators.required],
          weight: item.weight
        }));
      });
    }
  }

  addDish() {
    this.submitted = true;
    if (this.form?.valid) {
      (this.form?.get('dishes') as FormArray).push(this.fb.group({
        name: ['', Validators.required],
        weight: '50',
      }));
    }
  }

  submit() {
    this.submitted = true;
    if (this.form?.invalid) {
      return;
    }
    const payload = {
      ...this.form?.value
    };
    if (!payload.id) {
      delete payload.id;
    }
    if (this.id !== '0') {
      this.apiOrdersService.updateItemPost(payload).subscribe(() => {
        this.router.navigate(['/orders']);
      });
    } else {
      this.apiOrdersService.createItemPut(payload).subscribe(() => {
        this.router.navigate(['/orders']);
      });
    }
  }

  deleteArrayDishes(index: number) {
    (this.form?.get('dishes') as FormArray).removeAt(index);
  }
}
