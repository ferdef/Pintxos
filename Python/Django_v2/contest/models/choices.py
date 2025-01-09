from django.db import models
from django.utils.translation import gettext_lazy as _

class Tastes(models.TextChoices):
    DIDNT_LIKE = "DL", _("Didn't Like")
    TASTY = "TS", _("Tasty")
    VERY_TASTY = "VT", _("Very Tasty")
    EXCEPTIONAL = "EX", _("Exceptional")

class Presentations(models.TextChoices):
    DIDNT_LIKE = "DL", _("Didn't Like")
    WELL_PRESENTED = "WP", _("Well Presented")
    VERY_WELL = "VW", _("Very Well")
    EXCEPTIONAL = "EX", _("Exceptional")

class Originalities(models.TextChoices):
    DIDNT_LIKE = "DL", _("Didn't Like")
    ORIGINAL = "OR", _("Original")
    VERY_ORIGINAL = "VO", _("Very Original")
    EXCEPTIONAL = "EX", _("Exceptional")