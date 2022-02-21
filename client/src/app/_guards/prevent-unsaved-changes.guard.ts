import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { ConfirmService } from '../_services/confirm.service';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {

  constructor(private ConfirmService: ConfirmService) {}

  canDeactivate(component: MemberEditComponent): Observable<boolean> | boolean {
    // checks if any updates and prevents accidental changing of pages
    if (component.editForm.dirty) {
      return this.ConfirmService.confirm()
    }
    return true;
  }
  
}
