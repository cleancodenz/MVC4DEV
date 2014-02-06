using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace SessionLess.CustomModelValidator
{
    public class AllRequiredValidatorProvider : ModelValidatorProvider
    {



        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            var allRequiredAttribute =
            TypeDescriptor.GetAttributes(metadata.ContainerType)
            .OfType<AllRequiredAttribute>().FirstOrDefault();

            if (allRequiredAttribute != null)
            {
                if (metadata.PropertyName == "Title")
                {
                    var property = metadata.ContainerType.GetProperty(metadata.PropertyName);

                    var requiredValidator = new RequiredAttribute() { ErrorMessage = "Required" };
                    yield return new RequiredAttributeAdapter(
                                          metadata,
                                          context,
                                          requiredValidator
                                      );
                }
                /**
                   var isOptional = property.GetCustomAttributes(
                                               typeof(NotRequiredAttribute),
                                               false
                                            )
                                            .Any();
                   if (!isOptional)
                   {
                       var requiredValidator = new RequiredAttribute() { ErrorMessage = "Required" };
                       yield return new RequiredAttributeAdapter(
                                             metadata,
                                             context,
                                             requiredValidator
                                         );
                   }
                 * */
            }
        }
    }
}