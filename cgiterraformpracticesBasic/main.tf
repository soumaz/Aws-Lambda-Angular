module "simple" {
  source      = "./modules/simple"
  server_port = "${var.server_port}"
  key_name    = "${var.key_name}"
  tags        = "${var.tags}"
}
