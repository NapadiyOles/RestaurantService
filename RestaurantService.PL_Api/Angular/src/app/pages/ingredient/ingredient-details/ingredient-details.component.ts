import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiOrdersService} from '../../../core/_services/api.orders.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ApiIngredientService} from '../../../core/_services/api.ingredient.service';

@Component({
  selector: 'app-ingredient-details',
  templateUrl: './ingredient-details.component.html',
  styleUrls: ['./ingredient-details.component.scss'],
  providers: [ApiIngredientService]
})
export class IngredientDetailsComponent implements OnInit {
  form: FormGroup;
  submitted = false;
  id: any;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private apiIngredientService: ApiIngredientService
  ) {
  }

  ngOnInit(): void {
    this.id = this.route.snapshot?.paramMap?.get('id');
    if (this.id !== '0') {
      this.initForm(this.id);
    } else {
      this.initForm(null);
    }
  }

  initForm(data) {
    data ? data = JSON.parse(data) : data = null;
    this.form = this.fb.group({
      name: [data?.name || '', [Validators.required, Validators.pattern('^[a-zA-Z _]+$')]],
      id: [data?.id || null]
    });
    this.form.get('name').valueChanges.subscribe((val) => {
      if (val.length === 1 && val === ' ') {
        this.form.get('name').setValue('', {emitEvent: false})
      }
    })
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
      this.apiIngredientService.updateItemPost(payload).subscribe(() => {
        this.router.navigate(['/ingredients']);
      });
    } else {
      this.apiIngredientService.createItemPut(payload).subscribe(() => {
        this.router.navigate(['/ingredients']);
      });
    }
  }
}
