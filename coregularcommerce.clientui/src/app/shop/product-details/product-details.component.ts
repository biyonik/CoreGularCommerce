import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/modules/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct = {} as IProduct;

  constructor(private shopService: ShopService, private activeRoute: ActivatedRoute, private bcService: BreadcrumbService) {
    this.bcService.set('@productDetails', ' ');
  }

  ngOnInit(): void {
    this.getProductDetail();
  }

  getProductDetail() {
    const id: number = Number(this.activeRoute.snapshot.paramMap.get('id'));
    this.shopService.getProduct(id).subscribe((product: IProduct) => {
      this.product = product;
      this.bcService.set('@productDetails', product.name);
    }, (error) => {
      console.warn("Ürün detayı hatası: ", error);
    });
  }

}
