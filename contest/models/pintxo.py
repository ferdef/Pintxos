from django.db import models
from django.contrib.auth.models import User
from . import Contest

class Pintxo(models.Model):
    name = models.CharField(max_length=100)
    description = models.TextField(max_length=2048, blank=True, null=True)
    owner = models.ForeignKey(User, blank=True, null=True, on_delete=models.SET_NULL)
    contest = models.ForeignKey(Contest, on_delete=models.CASCADE)

    def __unicode__(self):
        return f"{self.name} by {self.get_owner_name()}"
    
    def __str__(self):
        return f"{self.name} by {self.get_owner_name()}"

    def get_owner_name(self):
        return self.owner.get_full_name() if self.owner else "Unknown"
