import { Injectable } from '@angular/core';
import { Activity } from 'src/app/models/activity';
import { CartItems } from '../../models/cartItems';
import { CartItem } from '../../models/cartItem';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  addToCart(activity:Activity)
  {
    let item = CartItems.find(c=>c.activity.id==activity.id);
    if(item){
      item.quantity+=1;
    }
    else{
      let cartItem=new CartItem();
      cartItem.activity=activity;
      cartItem.quantity=1
      CartItems.push(cartItem);
    }
  }

  list():CartItem[]{
    return CartItems;
  }

  cancelJoin(activity:Activity){
    let item:CartItem = CartItems.find(c=>c.activity.id==activity.id);
    CartItems.splice(CartItems.indexOf(item),1);
  }
}
