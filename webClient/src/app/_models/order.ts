import { Customer } from './customer';
import { VacationPackage } from './vacation-package';
import { Manager } from './manager';

export class Order {
  id: number;
  price: number;
  vacationPackage: VacationPackage;
  customer: Customer;
  manager: Manager;
  creationDateTime: string;
  completedDateTime: string;
}
