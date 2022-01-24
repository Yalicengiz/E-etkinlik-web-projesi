import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Activity } from 'src/app/models/activity';
import { ActivityDetail } from 'src/app/models/activityDetail';
import { Customer } from 'src/app/models/customer';
import { Join } from 'src/app/models/join';
import { ActivityService } from 'src/app/services/activityService/activity.service';
import { CustomerService } from 'src/app/services/customerService/customer.service';
import { JoinService } from 'src/app/services/joinService/join.service';

@Component({
  selector: 'app-join',
  templateUrl: './join.component.html',
  styleUrls: ['./join.component.css'],
})
export class JoinComponent implements OnInit {
  activitys: ActivityDetail[] = [];
  joins:Join[]=[];
  customer:Customer;
  joinAddForm: FormGroup;
  constructor(
    private joinService: JoinService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private customerService:CustomerService,
    private activityService:ActivityService,
    private activatedRoute:ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params:any) => {
    this.createJoinAddForm();
    this.getbyActivityIdJoins(params['activityId']);
    this.getActivitys(params['activityId']);

    });

  }

  createJoinAddForm() {
    this.joinAddForm = this.formBuilder.group({
       customerId: [this.customer.customerId, Validators.required],
      joinDate: ['', Validators.required],
      returnDate: ['', Validators.required],
    });
  }

  join() {
    if (this.joinAddForm.valid) {
      let joinModel = Object.assign({}, this.joinAddForm.value);
      this.joinService.getJoins(joinModel).subscribe(response=>{
        this.joinService.addJoin(joinModel).subscribe(
          (response) => {
            this.toastrService.success('Etkinliğe katıldın.', 'Başarılı');
          },
          (responseError) => {
            this.toastrService.error(responseError.error);
          }
        );
      })


    }
  }
  getActivitys(id:number) {
    this.activityService.getById(id).subscribe((response) => {
      this.activitys=response.data;
    });
  }

  getCustomers(id:number){
    this.customerService.getById(id).subscribe(response=>{
      this.customer=response.data[0];

    })
  }

  getbyActivityIdJoins(id:number) {
    this.joinService. getbyActivityIdJoins(id).subscribe((response) => {
      this.joins = response.data;

    });
  }

}
