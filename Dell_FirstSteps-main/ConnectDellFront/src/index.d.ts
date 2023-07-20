declare module "@dds/components";
declare var DDS: any;

declare module "*.svg" {
  import type { DefineComponent } from "vue";
  const component: DefineComponent;
  export default component;
}
