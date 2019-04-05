output "config-map-aws-auth" {
  value = "${module.eks.config-map-aws-auth}"
}

output "kubeconfig" {
  value = "${module.eks.kubeconfig}"
}
