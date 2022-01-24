import { SuperuseraddComponent } from './src/app/components/superuseradd/superuseradd.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from 'src/app/components/admin/admin.component';
import { ActivityTypeAddComponent } from 'src/app/components/activityType-add/activityType-add.component';
import { ActivityTypeUpdateComponent } from 'src/app/components/activityType-update/activityType-update.component';
import { ActivityAddComponent } from 'src/app/components/activity-add/activity-add.component';
import { ActivityDetailComponent } from 'src/app/components/activity-detail/activity-detail.component';
import { ActivityUpdateComponent } from 'src/app/components/activity-update/activity-update.component';
import { ActivityComponent } from 'src/app/components/activity/activity.component';
import { IsFreeAddComponent } from 'src/app/components/isFree-add/isFree-add.component';
import { IsFreeUpdateComponent } from 'src/app/components/isFree-update/isFree-update.component';
import { CustomerComponent } from 'src/app/components/customer/customer.component';
import { LoginComponent } from 'src/app/components/login/login.component';
import { ProfileComponent } from 'src/app/components/profile/profile.component';
import { RegisterComponent } from 'src/app/components/register/register.component';
import { JoinComponent } from 'src/app/components/join/join.component';
import { LoginGuard } from 'src/app/guards/login.guard';


const routes: Routes = [
  //anasyfada ne gözüksün=>
  {path:"", pathMatch:"full",component:ActivityComponent},
  {path:"activitys", component:ActivityComponent},
  {path:"activitys/isFrees/:isFreeId", component:ActivityComponent},
  {path:"activitys/activityTypes/:activityTypeId",component:ActivityComponent},
  {path:"katildigim-etkinlikler",component:ActivityDetailComponent},
  {path:"activitys/joins/:id", component:JoinComponent},
  {path:"activitys/customer",component:CustomerComponent},
  {path:"activitys/activityTypeadd",component:ActivityTypeAddComponent,canActivate:[LoginGuard]},
  {path:"activitys/priceTypeadd", component:IsFreeAddComponent,canActivate:[LoginGuard]},
  {path:"activitys/activityadd", component:ActivityAddComponent,canActivate:[LoginGuard]},
  {path:"activitys/activityTypeupdate/:activityTypeId", component:ActivityTypeUpdateComponent,canActivate:[LoginGuard]},
  {path:"activitys/priceTypeupdate/:isFreeId", component:IsFreeUpdateComponent,canActivate:[LoginGuard]},
  {path:"activitys/activityupdate/:id", component:ActivityUpdateComponent,canActivate:[LoginGuard]},
  {path:"activitys/superUser", component:SuperuseraddComponent,canActivate:[LoginGuard]},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"admin",component:AdminComponent,canActivate:[LoginGuard]},
  {path:"profile",component:ProfileComponent,canActivate:[LoginGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
