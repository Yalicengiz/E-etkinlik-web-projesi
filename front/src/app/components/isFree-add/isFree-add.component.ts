import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';
import { PriceType } from 'src/app/models/priceType';
import { IsFreeService } from 'src/app/services/isFreeService/isFree.service';

@Component({
  selector: 'app-isFree-add',
  templateUrl: './isFree-add.component.html',
  styleUrls: ['./isFree-add.component.css'],
})
export class IsFreeAddComponent implements OnInit {
  isFreeAddForm: FormGroup;
  constructor(
    private isFreeService: IsFreeService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.createIsFreeAddForm();
  }

  createIsFreeAddForm() {
    this.isFreeAddForm = this.formBuilder.group({
      priceTypeName: ['', Validators.required],
    });
  }

  add() {
    if (this.isFreeAddForm.valid) {
      let isFreeModel = Object.assign({}, this.isFreeAddForm.value);
      this.isFreeService.add(isFreeModel).subscribe((data) => {
        this.toastrService.success('Fiyatlandırma Türü eklendi');
      });
      this.router.navigateByUrl('');
    } else {
      this.toastrService.error('Form hatalı');
    }
  }
}
